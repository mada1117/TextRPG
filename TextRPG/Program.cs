using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace TextRPG
{
    class Player1
    {
        public string Name { get; set; }
        public string Job { get; set; } = "전사";
        public int Level { get; set; } = 1;
        public int Attack { get; set; } = 10;
        public int Defense { get; set; } = 5;
        public int Hp { get; set; } = 100;
        public int Gold { get; set; } = 1500;

        public Player1(string name)
        {
            Name = name;
        }
    }
    class Item
    {

    }

    class StoreItem
    {

    }


    class Program
    {
        static Player1 player1;

        static void Main(string[] args)
        {
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
                Console.WriteLine("\n여정을 시작할 당신의 이름은 무엇입니까?");
                Console.Write(">> ");
                string playerName = Console.ReadLine();
                player1 = new Player1(playerName);
                VillageUI();
            }
            else
            {
                Console.WriteLine("당신의 여정이 시작도 하기 전에 끝납니다");
                return;
            }


            static void VillageUI()
            {
                while (true)
                {
                    Console.Clear();
                    Console.Title = "스파르타 마을";
                    Console.WriteLine("\n이 곳은 스파르타 마을. 던전에 들어가기 전 준비를 할 수 있습니다\n");
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점\n");

                    Console.WriteLine("원하시는 행동을 숫자로 입력해주세요.");
                    Console.Write(">> ");

                    string input = Console.ReadLine();

                    // 입력 처리
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("[상태 보기]를 선택하셨습니다.");
                            StatusUi();
                            break;

                        case "2":
                            Console.WriteLine("[인벤토리]를 선택하셨습니다.");
                            InventoryUi();
                            break;

                        case "3":
                            Console.WriteLine("[상점]을 선택하셨습니다.");
                            StoreUi();
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }

            static void StatusUi()
            {
                while (true)
                {
                    Console.Clear();
                    Console.Title = "상태 보기";
                    Console.WriteLine("\n상태 보기");
                    Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                    // 상태 정보 출력
                    Console.WriteLine($"Lv. {player1.Level:00}");
                    Console.WriteLine($"이름: {player1.Name} ( 직업: {player1.Job} )");
                    Console.WriteLine($"공격력 : {player1.Attack}");
                    Console.WriteLine($"방어력 : {player1.Defense}");
                    Console.WriteLine($"체 력 : {player1.Hp}");
                    Console.WriteLine($"Gold : {player1.Gold} G");

                    Console.WriteLine("\n0. 나가기");
                    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");
                    string input = Console.ReadLine();

                    if (input == "0") break;

                    Console.WriteLine("잘못된 입력입니다. 계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();
                }

            }

            static void InventoryUi()
            {
                Console.Clear();
                Console.Title = "인벤토리";
                Console.WriteLine("\n인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");
            }

            static void StoreUi()
            {
                Console.Clear();
                Console.Title = "상점";
                Console.WriteLine("\n상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");

                Console.WriteLine("[아이템 목록]");

            }

        }
    }
}
