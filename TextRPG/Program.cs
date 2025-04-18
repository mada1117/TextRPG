using System;
using System.Numerics;

namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 플레이어가 정보를 입력하는 것은 일단 보류
            Console.Title = "스파르타 던젼";
            Console.WriteLine("스파르타 던젼에 오신 여러분을 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");

            Console.Write(">> ");
            string playerName = Console.ReadLine();

            Console.WriteLine("\n직업을 선택해주세요. (선택지: 전사, 도적)");
            Console.Write(">> ");
            string playerJob = Console.ReadLine();

            Console.WriteLine($"\n환영합니다, {playerName}님! 모험을 시작합니다...");
            */


            // 게임 시작화면
            Console.Title = "==== 스파르타 던전 ====";
            Console.WriteLine("\n==== 스파르타 던전 ====");
            Console.WriteLine("깊고 어두운 던전 속, 한 전사의 전설이 다시 쓰여진다...\n");
            Console.WriteLine("당신은 스파르타 대륙의 용맹한 전사입니다.");
            Console.WriteLine("당신의 여정을 시작하시겠습니까? (Y/N)");
            Console.Write(">> ");
            string startChoice = Console.ReadLine();

            if (startChoice.ToUpper() == "Y")
            {
                Console.Clear();
                VillageUI();
            }
            else
            {
                Console.WriteLine("당신의 여정이 시작도 하기 전에 끝납니다");
                return;
            }


            static void VillageUI()
            {
                // 메뉴 출력
                Console.Title = "스파르타 마을";
                Console.WriteLine("\n이 곳은 스파르타 마을. 던전에 들어가기 전 준비를 할 수 있습니다\n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();

                Console.WriteLine(); // 줄바꿈

                // 입력 처리
                switch (input)
                {
                    case "1":
                        Console.WriteLine("[상태 보기]를 선택하셨습니다.");
                        // 상태 보기 코드 작성 예정
                        break;

                    case "2":
                        Console.WriteLine("[인벤토리]를 선택하셨습니다.");
                        // 인벤토리 코드 작성 예정
                        break;

                    case "3":
                        Console.WriteLine("[상점]을 선택하셨습니다.");
                        // 상점 코드 작성 예정
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}
