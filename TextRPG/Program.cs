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
        public int BaseAttack { get; set; } = 10;
        public int BaseDefense { get; set; } = 5;
        public int Hp { get; set; } = 100;
        public int Gold { get; set; } = 1500;
        public List<Item> Inventory { get; set; } = new List<Item>();

        public Player1(string name)
        {
            Name = name;
        }
    }
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool IsEquipped { get; set; } = false;
    }

    class StoreItem
    {   
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Price { get; set; }
        public bool IsSold { get; set; } = false;
    }


    class Program
    {
        static Player1 player1;

        static List<StoreItem> storeItems = new List<StoreItem>
        {
        new StoreItem { Name = "수련자 갑옷", Defense = 5, Description = "수련에 도움을 주는 갑옷입니다.", Price = 1000 },
        new StoreItem { Name = "무쇠갑옷", Defense = 9, Description = "무쇠로 만들어져 튼튼한 갑옷입니다.", Price = 1200, IsSold = true },
        new StoreItem { Name = "스파르타의 갑옷", Defense = 15, Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", Price = 3500 },
        new StoreItem { Name = "낡은 검", Attack = 2, Description = "쉽게 볼 수 있는 낡은 검 입니다.", Price = 600 },
        new StoreItem { Name = "청동 도끼", Attack = 5, Description = "어디선가 사용됐던거 같은 도끼입니다.", Price = 1500 },
        new StoreItem { Name = "스파르타의 창", Attack = 7, Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.", Price = 2000, IsSold = true }
        };


        static void Main(string[] args)
        {
            player1.Inventory.Add(new Item { Name = "무쇠갑옷", Defense = 9, Description = "무쇠로 만들어져 튼튼한 갑옷입니다.", IsEquipped = true });
            player1.Inventory.Add(new Item { Name = "스파르타의 창", Attack = 7, Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.", IsEquipped = true });


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

                    // 착용 장비에 따라 공격력과 방어력 계산
                    int bonusAtk = 0, bonusDef = 0;
                    foreach (var item in player1.Inventory)
                    {
                        if (item.IsEquipped)
                        {
                            bonusAtk += item.Attack;
                            bonusDef += item.Defense;
                        }
                    }

                    // 상태 정보 출력
                    Console.WriteLine($"Lv. {player1.Level:00}");
                    Console.WriteLine($"이름: {player1.Name} ( 직업: {player1.Job} )");
                    // 공격력에서 착용 장비의 공격력이 얼마나 더해졌는지 표시
                    Console.WriteLine($"공격력 : {player1.BaseAttack + bonusAtk} ({(bonusAtk >= 0 ? "+" : "")}{bonusAtk})");
                    Console.WriteLine($"방어력 : {player1.BaseDefense + bonusDef} ({(bonusAtk >= 0 ? "+" : "")}{bonusAtk})");
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
                while (true)
                {
                    Console.Clear();
                    Console.Title = "인벤토리";
                    Console.WriteLine("\n인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                    Console.WriteLine("[아이템 목록]");

                }
            }

            static void StoreUi()
            {
                while (true)
                {
                    Console.Clear();
                    Console.Title = "상점";
                    Console.WriteLine("\n상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                    Console.WriteLine($"[보유 골드] : {player1.Gold}");

                    Console.WriteLine("[아이템 목록]");
                    for (int i = 0; i < storeItems.Count; i++)
                    {
                        var item = storeItems[i];
                        string priceLabel = item.IsSold ? "구매완료" : $"{item.Price} G";
                        Console.WriteLine($"- {i + 1} {item.Name} | {(item.Attack > 0 ? $"공격력 +{item.Attack}" : $"방어력 +{item.Defense}")} | {item.Description} |  {priceLabel}");
                    }

                    Console.WriteLine("\n0. 나가기");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    string input = Console.ReadLine();

                    if (input == "0") break;
                }
            }

            static void PurchaseItem()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("상점 - 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                    Console.WriteLine($"[보유 골드] : {player1.Gold}");

                    Console.WriteLine("[아이템 목록]");
                    for (int i = 0; i < storeItems.Count; i++)
                    {
                        var item = storeItems[i];
                        string priceLabel = item.IsSold ? "구매완료" : $"{item.Price} G";
                        Console.WriteLine($"- {i + 1} {item.Name} | {(item.Attack > 0 ? $"공격력 +{item.Attack}" : $"방어력 +{item.Defense}")} | {item.Description} |  {priceLabel}");
                    }

                    Console.WriteLine("\n0. 나가기");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    string input = Console.ReadLine();

                    if (input == "0") break;

                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= storeItems.Count)
                    {
                        var selected = storeItems[choice - 1];

                        if (selected.IsSold)
                            Console.WriteLine("\n이미 구매한 아이템입니다.");
                        else if (player1.Gold >= selected.Price)
                        {
                            player1.Gold -= selected.Price;
                            selected.IsSold = true;

                            player1.Inventory.Add(new Item
                            {
                                Name = selected.Name,
                                Attack = selected.Attack,
                                Defense = selected.Defense,
                                Description = selected.Description
                            });

                            Console.WriteLine("\n구매를 완료했습니다.");
                        }
                        else
                        {
                            Console.WriteLine("\nGold가 부족합니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n잘못된 입력입니다.");
                    }

                    Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();
                }
            }



        }
    }
}
