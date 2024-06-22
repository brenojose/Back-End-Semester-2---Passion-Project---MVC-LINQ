namespace Project_Passion_BrenoSouza.Models
{
    public class ErrorViewModel
    {
        //<summary>
        // The unique identifier for the request that caused the error.
        //</summary>
        public string? RequestId { get; set; }

        //<summary>
        // Indicates whether the RequestId should be shown.
        //</summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
