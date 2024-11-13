using weekOneDayFour.Models;

namespace weekOneDayFour.Repository
{
    public static class Lists
    {
        public static List<studentModel> students { get; set; } = new List<studentModel>()
        {
            new studentModel(1,"nabeel","kondotty","dotnet")
        };
    }
}
