using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ModifierRoulette;

class MP
{
    //Modifiers
    static List<Modifier> modifiers = new List<Modifier>();

    public void Start()
    {
        Console.Title = "Modifier Roulette";
        Load();
        StartMainMenu();
    }

    private void Error()
    {
        Console.Clear();

        Console.WriteLine("Something went wrong...");
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey(true);

        StartMainMenu();
    }

    private void AddingModifier()
    {
        Console.Clear();

        //Add
        Console.WriteLine("You selected: Add modifier");

        string prompt = "Select option:\n";
        List<string?> options = new List<string?> { "Submit", "Return" };
        Menu mainMenu = new Menu(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                Console.Clear();

                //Setting values
                Console.WriteLine("Enter name of modifier:\n");
                string? nameModifier = Console.ReadLine();
                if (nameModifier == "" || modifiers.Exists(p => p._name == nameModifier))
                {
                    Error();
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Enter description of modifier:\n");
                    string? descriptionModifier = Console.ReadLine();
                    if (descriptionModifier == "")
                    {
                        Error();
                    }

                    Console.Clear();

                    Modifier modifier = new Modifier(nameModifier, descriptionModifier);
                    modifiers.Add(modifier);
                    Console.WriteLine("Modifier added \n");

                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey(true);
                    StartMainMenu();
                }
                break;

            case 1:
                StartMainMenu();
                break;
        }


    }

    private void DeletingModifier()
    {
        Console.Clear();

        //Delete
        Console.WriteLine("You selected: Delete modifier");

        string prompt = "Select option:\n";
        List<string?> options = new List<string?> { "Submit", "Return" };
        Menu mainMenu = new Menu(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                Console.Clear();

                //Getting name
                Console.WriteLine("Enter name of modifier:\n");
                string? _nameModifier = Console.ReadLine();

                if (_nameModifier != "" && modifiers.Remove(modifiers.FirstOrDefault(p => p._name == _nameModifier)))
                {
                    Console.Clear();

                    Console.WriteLine("Modifier deleted \n");

                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey(true);
                    StartMainMenu();
                }
                else
                {
                    Error();
                }
                break;
            case 1:
                StartMainMenu();
                break;
        }

        mainMenu.DisplayOptions();
        Console.ReadKey(true);
    }

    private void Check()
    {
        Console.Clear();

        //Check
        Console.WriteLine("You selected: Work with modifiers");

        string prompt = "Select option:\n";
        List<string?> options = new List<string?> { "Check all modifiers in program", "Check enabled modifiers", "Edit statuses", "Check description of modifier", "Delete all modifiers", "Return" };
        Menu mainMenu = new Menu(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                Console.Clear();

                string result = "In modifiers:";

                //Getting names
                foreach (Modifier mod in modifiers)
                {
                    result += $" {mod.GetName()} |";
                }

                Console.WriteLine($"{result} \n");

                Console.WriteLine("Press any key to return...");
                Console.ReadKey(true);
                Check();
                break;

            case 1:
                Console.Clear();

                string txt = "Enabled modifiers:";

                List<Modifier> enabledModifiers = modifiers.FindAll(p => p._isEnable == true);

                //Getting names
                foreach (Modifier mod in enabledModifiers)
                {
                    txt += $" {mod.GetName()} |";
                }

                Console.WriteLine($"{txt} \n");

                Console.WriteLine("Press any key to return...");
                Console.ReadKey(true);
                Check();
                break;

            case 2:
                Console.Clear();

                string oText = "Select option:\n";
                List<string?> optionsC = new List<string?> { "Change", "Return" };
                Menu changeMenu = new Menu(oText, optionsC);
                int selectedIndexC = changeMenu.Run();

                switch (selectedIndexC)
                {
                    case 0:
                        Console.Clear();

                        if (modifiers.Count == 0)
                        {
                            Error();
                        }
                        else
                        {
                            string resultText = "All modifiers:";

                            //Getting names
                            foreach (Modifier mod in modifiers)
                            {
                                resultText += $" {mod.GetName()}: {mod.GetStatus()} |";
                            }

                            Console.WriteLine($"{resultText} \nClick to continue...");
                            Console.ReadKey();
                            string textF = "Select modifier:\n";
                            List<string?> modifierList = new List<string?>();
                            foreach (Modifier mod in modifiers)
                            {
                                modifierList.Add(mod.GetName());
                            }
                            Menu modifierMenu = new Menu(textF, modifierList);
                            int selectedIndexM = modifierMenu.Run();

                            if (modifiers.Count == 0)
                            {
                                Error();
                            }
                            else
                            {
                                //Checking status
                                if (modifiers[selectedIndexM]._isEnable)
                                {
                                    modifiers[selectedIndexM]._isEnable = false;

                                    Console.Clear();

                                    Console.WriteLine("Status changed\n");
                                    Console.WriteLine("Press any key to return...");
                                    Console.ReadKey(true);
                                    Check();
                                }
                                else
                                {
                                    modifiers[selectedIndexM]._isEnable = true;

                                    Console.Clear();

                                    Console.WriteLine("Status changed\n");
                                    Console.WriteLine("Press any key to return...");
                                    Console.ReadKey(true);
                                    Check();
                                }
                            }
                            modifierMenu.DisplayOptions();
                            Console.ReadKey(true);
                        }
                        break;
                    case 1:
                        Check();
                        break;

                }

                changeMenu.DisplayOptions();
                Console.ReadKey(true);
                break;

            case 3:
                Console.Clear();

                string oTextA = "Select modifer:\n";
                List<string?> optionsCA = new List<string?> { "Select", "Return" };
                Menu desMenu = new Menu(oTextA, optionsCA);
                int selectedIndexCA = desMenu.Run();

                switch (selectedIndexCA)
                {
                    case 0:
                        Console.Clear();

                        if (modifiers.Count == 0)
                        {
                            Error();
                        }
                        else
                        {
                            //Filling new list
                            List<string?> modifierListA = new List<string?>();
                            foreach (Modifier mod in modifiers)
                            {
                                modifierListA.Add(mod.GetName());
                            }
                            string textFA = "Select modifier:\n";
                            Menu modifierMenu = new Menu(textFA, modifierListA);
                            int selectedIndexMA = modifierMenu.Run();


                            Console.Clear();

                            Console.WriteLine($"Modifier: {modifiers[selectedIndexMA].GetName()}");
                            Console.WriteLine($"Modifier description: {modifiers[selectedIndexMA].GetDescription()}\n");

                            Console.WriteLine("Status changed\n");
                            Console.WriteLine("Press any key to return...");
                            Console.ReadKey(true);
                            Check();


                            modifierMenu.DisplayOptions();
                            Console.ReadKey(true);
                        }
                        break;

                    case 1:
                        Console.Clear();

                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey(true);
                        Check();
                        break;
                }

                desMenu.DisplayOptions();
                Console.ReadKey(true);
                break;

            case 4:
                Console.Clear();

                string textAc = "Select option:\n";
                List<string?> optionsAc = new List<string?> { "Confirm", "Return" };
                Menu acMenu = new Menu(textAc, optionsAc);
                int selectedIndexAC = acMenu.Run();

                switch (selectedIndexAC)
                {
                    case 0:
                        Console.Clear();

                        modifiers.Clear();

                        Console.WriteLine("All modifiers were deleted\n");
                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey(true);
                        Check();
                        break;
                    case 1:
                        Console.Clear();

                        Console.WriteLine("Press any key to return...");
                        Console.ReadKey(true);
                        Check();
                        break;
                }

                acMenu.DisplayOptions();
                Console.ReadKey(true);


                break;

            case 5:
                StartMainMenu();
                break;

        }

        mainMenu.DisplayOptions();
        Console.ReadKey(true);
    }

    private void Spin()
    {
        Console.Clear();

        //Spin
        Console.WriteLine("You selected: Spin");
        if (modifiers.Count == 0)
        {
            Error();
        }
        else
        {
            Random rnd = new Random();
            int rndModifier = rnd.Next(1, modifiers.Count + 1);
            Console.WriteLine($"You get: {modifiers[rndModifier - 1].GetName()} \n");

            //Checking status
            if (modifiers[rndModifier - 1]._isEnable)
            {
                modifiers[rndModifier - 1]._isEnable = false;
            }
            else
            {
                modifiers[rndModifier - 1]._isEnable = true;
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey(true);
        }
    }

    private void Exit()
    {
        Console.Clear();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
        Save(modifiers);
        Environment.Exit(0);
    }

    private void StartMainMenu()
    {
        Console.Clear();

        string prompt = "Select option:\n";
        List<string?> options = new List<string?> { "Add modifier", "Delete modifier", "Spin", "Work with modifiers", "Exit" };
        Menu mainMenu = new Menu(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                AddingModifier();
                StartMainMenu();
                break;
            case 1:
                DeletingModifier();
                StartMainMenu();
                break;
            case 2:
                Spin();
                StartMainMenu();
                break;
            case 3:
                Check();
                StartMainMenu();
                break;
            case 4:
                Exit();
                break;

        }

        mainMenu.DisplayOptions();
        Console.ReadKey(true);
    }



    private void Save(List<Modifier> modifiers)
    {
        List<string?> names = new List<string>(), descriptions = new List<string>();
        List<bool> statuses = new List<bool>();

        string namesResult = "", descriptionsResult = "", statusesResult = "";

        //Loading from MP
        foreach (Modifier mod in modifiers)
        {
            names.Add(mod.GetName());
            descriptions.Add(mod.GetDescription());
            statuses.Add(mod.GetStatus());
        }
        string fullPath = Path.GetFullPath(@"Data.txt");

        StreamWriter sw = new StreamWriter(fullPath);

        for (int i = 0; i < modifiers.Count; i++)
        {
            if (i < modifiers.Count - 1)
            {
                namesResult += $"{names[i]}/";
                descriptionsResult += $"{descriptions[i]}/";
                if (statuses[i])
                {
                    statusesResult += "1/";
                }
                else
                {
                    statusesResult += "0/";
                }
            }
            else
            {
                namesResult += $"{names[i]}";
                descriptionsResult += $"{descriptions[i]}";
                if (statuses[i])
                {
                    statusesResult += "1";
                }
                else
                {
                    statusesResult += "0";
                }
            }
        }
        sw.WriteLine($"{namesResult}\n{descriptionsResult}\n{statusesResult}");
        sw.Close();
    }

    private void Load()
    {
        string namesResult = "", descriptionsResult = "", statusesResult = "", line = "";
        string fullPath = Path.GetFullPath(@"Data.txt");

        try
        {
            StreamReader sr = new StreamReader(fullPath);

            for (int i = 0; i < 3; i++)
            {
                line = sr.ReadLine();
                switch (i)
                {
                    case 0:
                        namesResult = line;
                        break;

                    case 1:
                        descriptionsResult = line;
                        break;

                    case 2:
                        statusesResult = line;
                        break;
                }
            }

            string[] names = namesResult.Split('/');
            string[] descriptions = descriptionsResult.Split('/');
            string[] statuses = statusesResult.Split('/');

            for (int i = 0; i <= names.Length - 1; i++)
            {
                if (statuses[i] == "1")
                {
                    modifiers.Add(new Modifier(names[i], descriptions[i], true));
                }
                else
                {
                    modifiers.Add(new Modifier(names[i], descriptions[i], false));
                }

            }
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}