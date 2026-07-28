namespace stock;

public class Utility
{
  public static bool PromptContinue(string message = "Do you want to contine or exit, y for continue, n for exit")
  {
    Console.WriteLine(message);

    string option = Console.ReadLine()!;
    return option == "n";
  }
}
