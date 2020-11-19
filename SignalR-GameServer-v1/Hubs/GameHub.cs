using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public GameHub()
        {
        }
        public static bool close = false;
        public static int userCount = 0;
        public static int characterCount = 0;
        AbstractFactory factory = new FirstFactory();
        public static List<List<String>> userInfoArray = new List<List<String>>();
        static ConcreteSubject observer = new ConcreteSubject();

        static Creator[] creators = new Creator[3];
        public static List<String> wordList = new List<String>();

        public static String givenWord = "";

        Context context;

        public static int xpRate = 1;

        public static int abilityXpRate = 1;

        public static string lastAbilityUser = "";

        private static List<Player> playerList = new List<Player>();

        private static TalismanBuilder builder;

        private static Shop shop = new Shop();

        private static WordPrototype lastWord = new WordPrototype("empty");

        private static bool usedClone = false;

        private static Target target = new Adapter();

        private static PointsColorAbstraction pointsColorAbstraction = new PointsColorRefinedAbstraction();

        private static SkinAbstraction skinAbstraction = new SkinAbstraction();
        private static Facade facade = new Facade();

        private static Collection collection = new Collection();
        private static Iterator iterator = collection.CreateIterator();

        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
            /*
            if (message == "labas" && !close)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", user, message);
              //  await Clients.Others.SendAsync("ReceiveMessage", user, "UZDARYTA");
                //await Clients.All.SendAsync("LockUnlockInput", "LOCK");

                //close = true;
            }
            */
            //await Clients.Caller.SendAsync("ReceiveMessage", user, "delivered: " + message);
            //singleton test
            // Singleton.Instance.EndTime = DateTime.Now;
            //await Clients.Caller.SendAsync("SentTimeDifference",Singleton.Instance.Difference() );
        }

        public async Task UseSpecialAbility(string character)
        {
            switch (character)
            {
                case "Tank":
                    context = new Context(new TankStrategy());
                    abilityXpRate = context.ContextInterface();
                    Console.WriteLine("UseSpecialAbility Tank: " + abilityXpRate);

                    break;
                case "Car":
                    context = new Context(new CarStrategy());
                    abilityXpRate = context.ContextInterface();
                    Console.WriteLine("UseSpecialAbility Car: " + abilityXpRate);

                    break;
                case "Person":
                    context = new Context(new PersonStrategy());
                    abilityXpRate = context.ContextInterface();
                    Console.WriteLine("UseSpecialAbility Person: " + abilityXpRate);

                    break;
                case "Plane":
                    context = new Context(new PlaneStrategy());
                    abilityXpRate = context.ContextInterface();
                    Console.WriteLine("UseSpecialAbility Plane: " + abilityXpRate);

                    break;
                default:
                    break;
            }
            lastAbilityUser = character;

            await Clients.All.SendAsync("InformThatSomeoneUseAbility");
        }

        public void MakeWords()
        {
            creators[0] = new RandomWordsCreator();
            creators[1] = new RandomLettersCreator();
            creators[2] = new RandomSentenceCreator();

            foreach (Creator creator in creators)
            {
                for (int i = 0; i < 10; i++)
                {
                    collection[i] = creator.FactoryMethod();
                }
            }
        }

        public async Task GetTimer()
        {
            Singleton.Instance.EndTime = DateTime.Now;
            await Clients.Caller.SendAsync("ReceiveTimer", Singleton.Instance.Difference());
        }
        public async Task GetUsernames()
        {
            await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
        }
        public async Task CheckCharacterCount(int characterCount)
        {
            if (characterCount == 4)
            {
                observer.SubjectState = 1;
                observer.Notify();
                MakeWords();

                iterator.Step = 1;
                givenWord = iterator.Next().word;
                await Clients.All.SendAsync("ReceiveCountdown", 5, givenWord);
            }
        }

        public async Task CheckWord(string word, string username)
        {
            if (word == givenWord)
            {
                await Clients.Caller.SendAsync("GetWinMessage", lastAbilityUser);
                await Clients.Others.SendAsync("GetLoseMessage");

                Singleton.Instance.EndTime = DateTime.Now;
                await Clients.All.SendAsync("ReceiveTimer", Singleton.Instance.Difference());

                for (int i = 0; i < playerList.Count; i++)
                {
                    if (playerList[i].username == username)
                    {
                        WinnerLoser winnerLoser = new WinnerLoser(playerList[i]);
                        winnerLoser.SetWinner();

                        playerList[i].points = playerList[i].points + 10 + abilityXpRate * xpRate * playerList[i].characterKoeficient;
                        Console.WriteLine("CheckWord abilityXPRate " + abilityXpRate);
                    }
                    else
                    {
                        WinnerLoser winnerLoser = new WinnerLoser(playerList[i]);
                        winnerLoser.SetLoser();
                    }

                    if (playerList[i].talisman != null)
                    {
                        Console.WriteLine("Suveike vartotojo talismanas");
                        int points = playerList[i].talisman.ActivateTalisman();
                        playerList[i].points += points;

                        Console.WriteLine("Pridedama: " + playerList[i].username + " talismano tasku: " + points);
                    }
                }

                if (abilityXpRate != 1)
                {
                    lastAbilityUser = "";
                    abilityXpRate = 1;
                    Console.WriteLine("CheckWord abilityXPRate =1");
                }


                if(observer.SubjectState == 4){
                   playerList = facade.ChangeToSecondLevel(playerList);
                }

                if(observer.SubjectState == 9){
                   playerList = facade.ChangeToThirdLevel(playerList);
                }




                await Clients.All.SendAsync("ReceiveAllUsernames", playerList);

                if (usedClone)
                {
                    givenWord = lastWord.word;
                    usedClone = false;
                }
                else
                {
                    iterator.Step = 1;
                    givenWord = iterator.Next().word;
                }

                Console.WriteLine("Last word: " + lastWord.word);
                Console.WriteLine("Game word: " + givenWord);
                WordPrototype gameWord = new WordPrototype(givenWord);
                lastWord = (WordPrototype)gameWord.Clone();
                await Clients.All.SendAsync("ReceiveCountdown", 5, givenWord);

                observer.SubjectState++;
                observer.Notify();
                await Clients.All.SendAsync("GetGameRound", observer.SubjectState);
            }
        }
        public async Task RequestGameRound()
        {
            await Clients.All.SendAsync("GetGameRound", observer.SubjectState);
        }

        public async Task PlayerReadyInGameWindow(string username)
        {
            characterCount++;
            observer.Attach(new ConcreteObserver(observer, username));
            await CheckCharacterCount(characterCount);
        }
        public async Task SelectCharacter(string character, string username)
        {
            switch (character)
            {
                case "Tank":
                    Tank tank = factory.createTank();

                    for (int i = 0; i < playerList.Count; i++)
                    {

                        if (playerList[i].username == username)
                        {
                            playerList[i].character = tank.type;
                            playerList[i].points = 0;
                            playerList[i].characterKoeficient = tank.koeficient;
                            playerList[i].pointsColor = "black";
                        }
                    }

                    await Clients.Caller.SendAsync("ReturnAvatarTitle", tank.type);

                    break;
                case "Car":
                    Car car = factory.createCar();

                    for (int i = 0; i < playerList.Count; i++)
                    {

                        if (playerList[i].username == username)
                        {
                            playerList[i].character = car.type;
                            playerList[i].points = 0;
                            playerList[i].characterKoeficient = car.koeficient;
                            playerList[i].pointsColor = "black";
                        }
                    }
                    await Clients.Caller.SendAsync("ReturnAvatarTitle", car.type);

                    break;
                case "Person":
                    Person person = factory.createPerson();


                    for (int i = 0; i < playerList.Count; i++)
                    {

                        if (playerList[i].username == username)
                        {
                            playerList[i].character = person.type;
                            playerList[i].points = 0;
                            playerList[i].characterKoeficient = person.koeficient;
                            playerList[i].pointsColor = "black";
                        }
                    }
                    await Clients.Caller.SendAsync("ReturnAvatarTitle", person.type);

                    break;
                case "Plane":
                    Plane plane = factory.createPlane();

                    for (int i = 0; i < playerList.Count; i++)
                    {

                        if (playerList[i].username == username)
                        {
                            playerList[i].character = plane.type;
                            playerList[i].points = 0;
                            playerList[i].characterKoeficient = plane.koeficient;
                            playerList[i].pointsColor = "black";
                        }
                    }
                    await Clients.Caller.SendAsync("ReturnAvatarTitle", plane.type);

                    break;
                default:
                    break;
            }
        }

        public async Task SetReady(string username)
        {
            Player newPlayer = new Player();
            newPlayer.username = username;
            newPlayer.isAbilityUsed = false;
            newPlayer.character = "";
            newPlayer.isWinner = false;
            newPlayer.isLoser = false;
            newPlayer.points = 0;

            if (userCount < 4)
            {

                playerList.Add(newPlayer);

                userCount++;
                await Clients.Caller.SendAsync("LoginLock", username);

                await Clients.Caller.SendAsync("PlayerIsReady", true);
                await Clients.All.SendAsync("ReadyUserCount", userCount);

                if (userCount > 3)
                {
                    await Clients.All.SendAsync("LoginLock", username);
                    await Clients.All.SendAsync("SentRedirectToAllPlayers");
                }
            }
            else
            {
                await Clients.All.SendAsync("LoginLock", username);
                await Clients.All.SendAsync("SentRedirectToAllPlayers");
            }
        }
        public async Task GetReadyUsersCount()
        {
            if (userCount > 3)
            {
                await Clients.Caller.SendAsync("LoginLock", "");
                return;
            }
            await Clients.Caller.SendAsync("ReadyUserCount", userCount);
        }
        public override Task OnConnectedAsync()
        {
            if (userCount == 0)
            {
                Singleton.Instance.StartTime = DateTime.Now;
            }

            UserHandler.ConnectedIds.Add(Context.ConnectionId);

            return base.OnConnectedAsync();
        }
        public async Task CalculateTime()
        {
            Singleton.Instance.EndTime = DateTime.Now;
            await Clients.Caller.SendAsync("SentTimeDifference", Singleton.Instance.Difference());
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task BuyGoldTalisman(string username)
        {
            builder = new GoldTalismanBuilder();
            shop.Construct(builder);
            builder.Talisman.Show();

            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].username == username)
                {
                    if (playerList[i].points >= Convert.ToInt32(builder.Talisman["price"]))
                    {
                        playerList[i].talisman = builder.Talisman;
                        playerList[i].points -= Convert.ToInt32(builder.Talisman["price"]);
                        await Clients.Caller.SendAsync("DisableAllTalismans");
                        await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
                    }
                }
            }
        }

        public async Task BuySilverTalisman(string username)
        {
            builder = new SilverTalismanBuilder();
            shop.Construct(builder);
            builder.Talisman.Show();

            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].username == username)
                {
                    if (playerList[i].points >= Convert.ToInt32(builder.Talisman["price"]))
                    {
                        playerList[i].talisman = builder.Talisman;
                        playerList[i].points -= Convert.ToInt32(builder.Talisman["price"]);
                        await Clients.Caller.SendAsync("DisableAllTalismans");
                        await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
                    }
                }
            }
        }
        public async Task BuyBronzeTalisman(string username)
        {
            builder = new BronzeTalismanBuilder();
            shop.Construct(builder);
            builder.Talisman.Show();

            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].username == username)
                {
                    if (playerList[i].points >= Convert.ToInt32(builder.Talisman["price"]))
                    {
                        playerList[i].talisman = builder.Talisman;
                        playerList[i].points -= Convert.ToInt32(builder.Talisman["price"]);
                        await Clients.Caller.SendAsync("DisableAllTalismans");
                        await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
                    }
                }
            }
        }
        public void PenaltyCommand()
        {
            Command command = new PenaltyCommand(playerList);

            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }

        public async Task UnlockAbilityCommand()
        {
            Command command = new UnlockAbilityCommand(playerList);

            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
            await Clients.All.SendAsync("EnableAbilityButton");
        }
        public void PrizeCommand()
        {
            Command command = new PrizeCommand(playerList);

            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }

        public void clonePrototype()
        {
            usedClone = true;
        }

        public async Task SendUsernameToAPI(string username)
        {
            Console.WriteLine(username);
            await Clients.Caller.SendAsync("ReceiveUsernameFromAPI", target.RequestUsername(username));
        }


        public async Task receivePointsColor(string color, string username)
        {
            pointsColorAbstraction.Implementor = new ConcretePointsColorImplementor();

            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].username == username)
                {
                    switch (color)
                    {
                        case "green":
                            playerList[i].pointsColor = pointsColorAbstraction.GetGreenPointsColor();
                            break;
                        case "blue":
                            playerList[i].pointsColor = pointsColorAbstraction.GetBluePointsColor();
                            break;
                        case "red":
                            playerList[i].pointsColor = pointsColorAbstraction.GetRedPointsColor();
                            break;
                        default:
                            break;
                    }
                }
            }

            await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
        }


        public async Task receiveSkin(string username)
        {

            skinAbstraction.Implementor = new ConcreteSkinImplementor();

            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].username == username)
                {
                    switch (playerList[i].character)
                    {
                        case "FirstTank":
                            playerList[i].skin = skinAbstraction.GetTankSkin();
                            break;
                        case "SecondTank":
                            playerList[i].skin = skinAbstraction.GetTankSkin();
                            break;
                        case "ThirdTank":
                            playerList[i].skin = skinAbstraction.GetTankSkin();
                            break;

                        case "FirstPerson":
                            playerList[i].skin = skinAbstraction.GetPersonSkin();
                            break;
                        case "SecondPerson":
                            playerList[i].skin = skinAbstraction.GetPersonSkin();
                            break;
                        case "ThirdPerson":
                            playerList[i].skin = skinAbstraction.GetPersonSkin();
                            break;

                        case "FirstPlane":
                            playerList[i].skin = skinAbstraction.GetPlaneSkin();
                            break;
                        case "SecondPlane":
                            playerList[i].skin = skinAbstraction.GetPlaneSkin();
                            break;
                        case "ThirdPlane":
                            playerList[i].skin = skinAbstraction.GetPlaneSkin();
                            break;

                        case "FirstCar":
                            playerList[i].skin = skinAbstraction.GetCarSkin();
                            break;
                        case "SecondCar":
                            playerList[i].skin = skinAbstraction.GetCarSkin();
                            break;
                        case "ThirdCar":
                            playerList[i].skin = skinAbstraction.GetCarSkin();
                            break;
                    }
                }
            }

            await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
        }
    }
    public static class UserHandler
    {
        public static List<string> ConnectedIds = new List<string>();
    }
}