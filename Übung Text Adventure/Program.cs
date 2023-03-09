bool weapon = false;
bool killed = false;

void IntroduceTheGame()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Adventure Game!");
    Console.WriteLine("==============================");
    Console.WriteLine("You are a Rebel Fighter and you have been captured by the empire.");
    Console.WriteLine("You escaped from your prison cell and need to find a way out of the Star Destroyer.");
    Console.WriteLine("You can choose to walk in multiple directions to find a way out.");
    Console.WriteLine("Let's start with your name: ");
    string name = Console.ReadLine()!;
    Console.WriteLine($"Good luck, {name}!");
}

void IntroScene()
{
    Console.WriteLine("You are at a crossroads, and you can choose to go down any of the four hallways. Where would you like to go?");
    Console.WriteLine("Options: north/east/south/west");
    string direction = Console.ReadLine()!;
    switch (direction)
    {
        case "north":
            while (direction == "north")
            {
                Console.WriteLine("You find that this door opens into an empty room.");
                Console.WriteLine("Options: north/east/south/west");
                direction = Console.ReadLine()!;
            }
            break;

        case "east": ShowPrisoners(); break;

        case "south": Hangar(); break;

        case "west": ShowGroupOfStormtrooper(); break;
    }
}

void ShowPrisoners()
{
    Console.WriteLine("As you walk in the room, you are being watched by other prisoners, but you are not able to help them.");
    Console.WriteLine("Where are you going next?");
    Console.WriteLine("Options: north/east/west");
    string direction = Console.ReadLine()!;
    while (direction == "south")
    {
        Console.WriteLine("Invalid input, try again!");
        direction = Console.ReadLine()!;
    }

    switch (direction)
    {
        case "north":
            Console.WriteLine("You find that this door opens into an empty room.");

            if (weapon == false)
            {
                Console.WriteLine("But your blaster lies on the ground.");
                weapon = true;
            }


            Console.WriteLine("Options: north/east/west");
            direction = Console.ReadLine()!;
            if (direction == "north")
            {
                while (direction == "north")
                {
                    Console.WriteLine("You find that this door opens into an empty room.");
                    Console.WriteLine("Options: north/east/west");
                    direction = Console.ReadLine()!;
                    if (direction == "east") { Stormtrooper(); }
                    else if (direction == "west") { IntroScene(); }
                }
            }
            else if (direction == "east") { Stormtrooper(); }
            else if (direction == "west") { IntroScene(); }


            break;

        case "east": Stormtrooper(); break;

        case "west": IntroScene(); break;
    }
}

void Stormtrooper()
{
    if (killed == false)
    {

        Console.WriteLine("You ran into a Stormtrooper. You can either run or fight it. What do yu do?");
        Console.WriteLine("Options: flee/fight");
        string decision = Console.ReadLine()!;
        switch (decision)
        {
            case "flee": ShowPrisoners(); break;
            case "fight":
                if (weapon == false) { Console.WriteLine("The Stormtrooper has killed you. Game Over!"); }
                else if (weapon == true)
                {


                    killed = true;
                    Console.WriteLine("You kill the Stormtrooper with your blaster you found earlier.");
                    Console.WriteLine("Where do you go now?");

                    Console.WriteLine("Options: west/south");
                    string direction = Console.ReadLine()!;
                    if (direction == "west") { ShowPrisoners(); }
                    if (direction == "south") { Console.WriteLine("You escaped! Well done soldier!"); return; }
                }
                break;
        }
    }

    if (killed == true)
    {
        Console.WriteLine("You see the Stormtrooper that you killed earlier. What a relief! Where are you going now?");
        Console.WriteLine("Options: west/south");
        string direction2 = Console.ReadLine()!;
        if (direction2 == "west") { ShowPrisoners(); }
        if (direction2 == "south") { Console.WriteLine("You escaped! Well done soldier!"); return;}
    }
}

void Hangar()
{
    Console.WriteLine("You are in the hangar. There are two doors. Try to find the Escape Pod or go back.");
    Console.WriteLine("Options: north/east/west");
    string direction = Console.ReadLine()!;
    switch (direction)
    {
        case "north": IntroScene(); break;
        case "east": Console.WriteLine("You escaped! Well done soldier!"); break;
        case "west": Console.WriteLine("You ran into a room full of Stormtroopers. You get killed. Game Over!"); break;
    }
}

void ShowGroupOfStormtrooper()
{
    Console.WriteLine("You see a group of Stormtroopers. You need to go quickly before they spot you. Where are you going?");
    Console.WriteLine("Options: north/east/south");
    string direction = Console.ReadLine()!;
    switch (direction)
    {
        case "north": EscapeInEscapePod(); break;
        case "east": IntroScene(); break;
        case "south":
            while (direction == "south")
            {
                Console.WriteLine("You find that this door opens into an empty room.");
                Console.WriteLine("Options: north/east/south");
                direction = Console.ReadLine()!;
            }
            break;
    }
}

void EscapeInEscapePod()
{
    Console.WriteLine("You get into a new room. Across the room you see Escape Pods. Where are you going?");
    Console.WriteLine("Options: north/south");
    string direction = Console.ReadLine()!;
    switch (direction)
    {
        case "north": Console.WriteLine("You escaped! Well done soldier!"); break;
        case "south": ShowGroupOfStormtrooper(); break;
    }
}

IntroduceTheGame();
IntroScene();
