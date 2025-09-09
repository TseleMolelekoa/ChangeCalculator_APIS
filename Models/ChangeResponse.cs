namespace ChangeCalculator.Models
{
    public class ChangeResponse
    {
        public int R200 { get; set; }
        public int R100 { get; set; }
        public int R50 { get; set; }
        public int R20 { get; set; }
        public int R10 { get; set; }
        public int R5 { get; set; }
        public int R2 { get; set; }
        public int R1 { get; set; }
        
        [System.Text.Json.Serialization.JsonPropertyName("50c")]
        public int Fifty_Cents { get; set; }
        
        [System.Text.Json.Serialization.JsonPropertyName("20c")]
        public int Twenty_Cents { get; set; }
        
        [System.Text.Json.Serialization.JsonPropertyName("10c")]
        public int Ten_Cents { get; set; }
    }
}