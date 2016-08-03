namespace ImcFramework.WcfInterface.TransferMessage
{
    /// <summary>
    /// ITransferMessage for the distribution facility.
    /// </summary>
    public interface ITransferMessage
    {
        /// <summary>
        /// The servicetype of transfer message.
        /// </summary>
        EServiceType ServiceType { get; set; }

        /// <summary>
        /// The user.
        /// </summary>
        string User { get; set; }

        /// <summary>
        /// The callback method name.
        /// </summary>
        string CallbackMethodName { get; set; }
    }
}
