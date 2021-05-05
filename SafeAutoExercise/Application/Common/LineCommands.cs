namespace SafeAutoExercise.Common.Enums
{
    public class LineCommand
    {
        private LineCommand(string value) { Value = value; }

        public string Value { get; set; }

        public static LineCommand Driver { get { return new LineCommand("Driver"); } }
        public static LineCommand Trip { get { return new LineCommand("Trip"); } }
    }
}
