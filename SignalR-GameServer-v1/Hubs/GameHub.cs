using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SignalR_GameServer_v1.Hubs
{
    public class GameHub : Hub
    {
        public GameHub()
        {
        }

    
        public static int userCount = 0;
        public static int characterCount = 0;
        AbstractFactory factory = new FirstFactory();
      
        static ConcreteSubject observer = new ConcreteSubject();

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

        private static AbstractClass firstLevel = new FirstLevelWord();

        private static AbstractClass secondLevel = new SecondLevelWord();

        private static AbstractClass thirdLevel = new ThirdLevelWord();

        private static Handler h1 = new ReverseWordHandler();

        private static Handler h2 = new FullWordHandler();

        private static Handler h3 = new PartWordHandler();

        private static Handler h4 = new LengthWordHandler();

        private static StateContext _stateContext = new StateContext(new WinterState());
        
       private static Chatroom chatroom = new Chatroom();
       
       private static Originator originator = new Originator();
       
       private static Caretaker caretaker = new Caretaker();
       
       private static ParametersGroup parametersGroup = new ParametersGroup();

        public async Task SendMessage(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
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
            parametersGroup.Attach(new Parameter(1,2.5,"black"));
            int x = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i <= 2)
                {
                    Console.WriteLine("FIRST LEVEL");
                    Word[] list = firstLevel.TemplateMethod();
                    collection[x] = list[0];
                    x++;
                    collection[x] = list[1];
                    x++;
                    collection[x] = list[2];
                    x++;

                    Composite word = new Composite(list[0].word);
                    Composite letters = new Composite(list[1].word);
                    Composite sentence = new Composite(list[2].word);

                    letters.Add(sentence);
                    word.Add(letters);
                    word.Display(1);

                    collection[x] = new Composite(word.getSequence());
                    x++;
                }

                if (i >= 3 && i <= 5)
                {
                    Console.WriteLine("SECOND LEVEL");
                    Word[] list = secondLevel.TemplateMethod();
                    collection[x] = list[0];
                    x++;
                    collection[x] = list[1];
                    x++;
                    collection[x] = list[2];
                    x++;

                    Composite word = new Composite(list[0].word);
                    Composite letters = new Composite(list[1].word);
                    Composite sentence = new Composite(list[2].word);

                    letters.Add(sentence);
                    word.Add(letters);
                    word.Display(1);

                    collection[x] = new Composite(word.getSequence());
                    x++;
                }

                if (i >= 6)
                {
                    Console.WriteLine("Third LEVEL");
                    Word[] list = thirdLevel.TemplateMethod();
                    collection[x] = list[0];
                    x++;
                    collection[x] = list[1];
                    x++;
                    collection[x] = list[2];
                    x++;

                    Composite word = new Composite(list[0].word);
                    Composite letters = new Composite(list[1].word);
                    Composite sentence = new Composite(list[2].word);

                    letters.Add(sentence);
                    word.Add(letters);
                    word.Display(1);

                    collection[x] = new Composite(word.getSequence());
                    x++;
                }
            }

            Console.WriteLine(collection[0]);
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
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                MakeWords();
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                Console.WriteLine("MakeWords ticks: " + ts.Ticks);

                iterator.Step = 1;
                givenWord = iterator.Next().word;
                await Clients.All.SendAsync("ReceiveCountdown", 5, givenWord);
                await Clients.All.SendAsync("SeasonState", _stateContext.State.GetType().Name);
            }
        }

        public async Task CheckWord(string word, string username)
        {
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            h3.SetSuccessor(h4);

            double chainPoints = h1.HandleRequest(word, givenWord);

            if (chainPoints >= 1)
            {
                parametersGroup.Accept(new ColorVisitor());
                if (parametersGroup.getParameter(0).Opacity > 0.1)
                {
                    parametersGroup.Accept(new OpacityVisitor());  
                    parametersGroup.Accept(new FontSizeVisitor());
                }

                Console.WriteLine("params");
                Console.WriteLine("Color: "+parametersGroup.getParameter(0).Color);
                Console.WriteLine("Opacity: "+parametersGroup.getParameter(0).Opacity);
                Console.WriteLine("FontSize: "+parametersGroup.getParameter(0).FontSize);
                
                await Clients.All.SendAsync(
                    "ReceiveWordStyle",
                    Math.Round(parametersGroup.getParameter(0).Opacity, 2),
                    Math.Round(parametersGroup.getParameter(0).FontSize, 2),
                    parametersGroup.getParameter(0).Color);
                
                List<Player> playerListCopy = new List<Player>();

                playerList.ForEach(delegate (Player player)
                {
                    playerListCopy.Add((Player)player.Clone());
                });
                
                originator.State = playerListCopy;
                caretaker.Memento = originator.CreateMemento();
            }

            if (chainPoints < 1)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    if (playerList[i].username == username)
                    {
                        playerList[i].points = playerList[i].points + Convert.ToInt32(10 * chainPoints);
                    }
                }

                await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
            }
            else
            {
                await Clients.Caller.SendAsync("GetWinMessage", lastAbilityUser);
                await Clients.Others.SendAsync("GetLoseMessage");
                
                await Clients.All.SendAsync("SeasonState", _stateContext.State.GetType().Name);
                _stateContext.Request();
                
                Singleton.Instance.EndTime = DateTime.Now;
                await Clients.All.SendAsync("ReceiveTimer", Singleton.Instance.Difference());

                for (int i = 0; i < playerList.Count; i++)
                {
                    playerList[i].receivedEmoji = "";
                    playerList[i].receivedFrom = "";
                    if (playerList[i].username == username)
                    {
                        WinnerLoser winnerLoser = new WinnerLoser(playerList[i]);
                        winnerLoser.SetWinner();

                        playerList[i].points = playerList[i].points + Convert.ToInt32(10 * chainPoints) +
                                               abilityXpRate * xpRate * playerList[i].characterKoeficient;
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

                    if (playerList[i].points >= 100)
                    {
                        await Clients.All.SendAsync("RedirectToLobby",playerList[i].username);
                        endGame();
                        return;
                    }
                }

                if (abilityXpRate != 1)
                {
                    lastAbilityUser = "";
                    abilityXpRate = 1;
                    Console.WriteLine("CheckWord abilityXPRate =1");
                }


                if (observer.SubjectState == 4)
                {
                    playerList = facade.ChangeToSecondLevel(playerList);

                    foreach (var player in playerList)
                    {
                        player.permissionProxy.giveShopPermission();
                    }
                }

                if (observer.SubjectState == 9)
                {
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
                lastWord = (WordPrototype) gameWord.Clone();
                await Clients.All.SendAsync("ReceiveCountdown", 5, givenWord);

                observer.SubjectState++;
                observer.Notify();
                await Clients.All.SendAsync("GetGameRound", observer.SubjectState);
            }
        }

        public void endGame()
        {
            userCount = 0;
            characterCount = 0;
            observer = new ConcreteSubject();
            givenWord = "";
            xpRate = 1;
            abilityXpRate = 1;
            lastAbilityUser = "";
            playerList = new List<Player>();
            lastWord = new WordPrototype("empty");
            usedClone = false;
            target = new Adapter();
            pointsColorAbstraction = new PointsColorRefinedAbstraction();
            skinAbstraction = new SkinAbstraction();
            facade = new Facade();
            collection = new Collection();
            iterator = collection.CreateIterator();
            firstLevel = new FirstLevelWord();
            secondLevel = new SecondLevelWord();
            thirdLevel = new ThirdLevelWord();
            h1 = new ReverseWordHandler();
            h2 = new FullWordHandler();
            h3 = new PartWordHandler();
            h4 = new LengthWordHandler();
            _stateContext = new StateContext(new WinterState());
            chatroom = new Chatroom();
            originator = new Originator();
            caretaker = new Caretaker();
            parametersGroup = new ParametersGroup();
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
        
        public async Task SendEmoji(string emoji, string to,string from)
        {
            InterpreterContext context = new InterpreterContext(emoji);

            List<Expression> tree = new List<Expression>();

            tree.Add(new EyesExpression());

            tree.Add(new MouthExpression());
            
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            if (to == "All")
            {
                foreach (var player in playerList)
                {
                    if (player.username == from)
                    {
                        foreach (var playerTo in playerList)
                        {
                            player.Send(playerTo.username, context.Output);     
                        }
                    }
                }
            }
            else
            {
                foreach (var player in playerList)
                {
                    if (player.username == from)
                    {
                        player.Send(to, context.Output);
                    }
                }    
            }
            
            Console.WriteLine("{0} = {1}", emoji, context.Output);
            
            await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
        }
        
        public async Task SetReady(string username)
        {
            Console.WriteLine("OK");
            Player newPlayer = new Player();
            newPlayer.username = username;
            newPlayer.isAbilityUsed = false;
            newPlayer.character = "";
            newPlayer.isWinner = false;
            newPlayer.isLoser = false;
            newPlayer.points = 0;
            newPlayer.receivedEmoji = "";
            newPlayer.receivedFrom = "";
            Console.WriteLine("OK-P: "+username);
            if (userCount == 0)
            {
                newPlayer.permissionProxy.giveCommandPermission();
            }

            if (userCount < 4)
            {
                playerList.Add(newPlayer);
                Console.WriteLine("CH");
                chatroom.Register(newPlayer);
                Console.WriteLine("CH-OK");
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

        public async Task TimeTravelAction()
        {
            originator.SetMemento(caretaker.Memento);
            playerList = originator.State;
            await Clients.All.SendAsync("ReceiveAllUsernames", playerList);
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