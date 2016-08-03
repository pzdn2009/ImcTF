namespace ImcFramework.Data
{
    /// <summary>
    /// Indicates an execution result.
    /// </summary>
    public class ExecuteResult
    {
        /// <summary>
        /// The execution is success or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The execution message.
        /// When <see cref="Success"/> is true , the Message is empty, otherwise ,the message holds the exception message or other.
        /// </summary>
        public string Message { get; set; }
    }
}
