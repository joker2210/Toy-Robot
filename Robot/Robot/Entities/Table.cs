namespace Robot.Entities
{
    public class Table
    {
        int Width;
        int Length;
        
        //Square table. One side dimension should be assiged to both length and width
        public Table(int sideDimension)
        {
            Width = sideDimension;
            Length = sideDimension;
        }

        public bool IsValidLocation(int xAxis, int yAxis) => xAxis >= 0 && xAxis < Width && yAxis >= 0 && yAxis < Length;
    }
}
