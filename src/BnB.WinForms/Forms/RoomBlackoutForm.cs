using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.UI;

namespace BnB.WinForms.Forms;

/// <summary>
/// Dialog for creating a room blackout period.
/// </summary>
public partial class RoomBlackoutForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly int _roomTypeId;
    private readonly string _roomDescription;
    private readonly DateTime _initialDate;

    public RoomBlackoutForm(BnBDbContext dbContext, int roomTypeId, string roomDescription, DateTime initialDate)
    {
        _dbContext = dbContext;
        _roomTypeId = roomTypeId;
        _roomDescription = roomDescription;
        _initialDate = initialDate;

        InitializeComponent();
    }

    private void RoomBlackoutForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        lblRoom.Text = $"Room: {_roomDescription}";
        dtpStartDate.Value = _initialDate;
        dtpEndDate.Value = _initialDate;

        // Populate reason dropdown with common options
        cboReason.Items.AddRange(new object[]
        {
            "Maintenance",
            "Owner Use",
            "Renovation",
            "Seasonal Closure",
            "Other"
        });
        cboReason.SelectedIndex = 0;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
        {
            MessageBox.Show("End date must be on or after start date.",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpEndDate.Focus();
            return;
        }

        var reason = cboReason.Text;
        if (cboReason.Text == "Other" && !string.IsNullOrWhiteSpace(txtOtherReason.Text))
        {
            reason = txtOtherReason.Text.Trim();
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            MessageBox.Show("Please enter a reason for the blackout.",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboReason.Focus();
            return;
        }

        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        // Check for conflicts with existing bookings
        var roomType = _dbContext.RoomTypes.Find(_roomTypeId);
        if (roomType != null)
        {
            var conflictingBooking = _dbContext.Accommodations
                .Where(a => a.PropertyAccountNumber == roomType.PropertyAccountNumber
                         && a.UnitName == roomType.Name
                         && a.ArrivalDate <= endDate
                         && a.DepartureDate > startDate)
                .Select(a => new { a.ConfirmationNumber, a.FirstName, a.LastName, a.ArrivalDate, a.DepartureDate })
                .FirstOrDefault();

            if (conflictingBooking != null)
            {
                MessageBox.Show(
                    $"Cannot create blackout - there is an existing booking:\n\n" +
                    $"Conf#: {conflictingBooking.ConfirmationNumber}\n" +
                    $"Guest: {conflictingBooking.FirstName} {conflictingBooking.LastName}\n" +
                    $"Dates: {conflictingBooking.ArrivalDate:MM/dd/yyyy} - {conflictingBooking.DepartureDate:MM/dd/yyyy}",
                    "Conflict Detected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
        }

        // Check for overlapping blackouts
        var overlappingBlackout = _dbContext.RoomBlackouts
            .Where(b => b.RoomTypeId == _roomTypeId
                     && b.StartDate <= endDate
                     && b.EndDate >= startDate)
            .Select(b => new { b.StartDate, b.EndDate, b.Reason })
            .FirstOrDefault();

        if (overlappingBlackout != null)
        {
            MessageBox.Show(
                $"Cannot create blackout - there is an overlapping blackout:\n\n" +
                $"Dates: {overlappingBlackout.StartDate:MM/dd/yyyy} - {overlappingBlackout.EndDate:MM/dd/yyyy}\n" +
                $"Reason: {overlappingBlackout.Reason}",
                "Conflict Detected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        // Create the blackout
        var blackout = new RoomBlackout
        {
            RoomTypeId = _roomTypeId,
            StartDate = startDate,
            EndDate = endDate,
            Reason = reason,
            EntryDate = DateTime.Now,
            EntryUser = Environment.UserName
        };

        _dbContext.RoomBlackouts.Add(blackout);
        _dbContext.SaveChanges();

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void cboReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        var isOther = cboReason.Text == "Other";
        txtOtherReason.Visible = isOther;
        lblOtherReason.Visible = isOther;
    }
}
