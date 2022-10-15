using Aisoftware.Tracker.Borders.Models;

namespace Aisoftware.Tracker.Borders.ViewModels;
public class ReportViewModel
{
    public Group? Group { get; set; }
    public IEnumerable<Group>? Groups { get; set; }
    public Device? Device { get; set; }
    public IEnumerable<Device>? Devices { get; set; }

}
