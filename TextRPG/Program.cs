namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "스파르타 던젼";
            Console.WriteLine("스파르타 던젼에 오신 여러분을 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");

            Console.Write(">> ");
            string playerName = Console.ReadLine();

            Console.WriteLine($"\n환영합니다, {playerName}님! 모험을 시작합니다...");
        }
    }
}
