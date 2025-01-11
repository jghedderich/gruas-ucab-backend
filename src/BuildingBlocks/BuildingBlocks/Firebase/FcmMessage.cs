

namespace BuildingBlocks.Firebase;

public class FcmMessage
{
    public string To { get; set; } = default!;
    public string Priority { get; set; } = default!;
    public Notification Notification { get; set; } = default!;
}

public class Notification
{
    public string Title { get; set; } = default!;
    public string Body { get; set; } = default!;
}
