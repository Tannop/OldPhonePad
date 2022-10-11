class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Started");
        //string answer;
        string input = Console.ReadLine();
        string answer = OldPhonePad(input);
        Console.WriteLine(answer);
    }

    private static String OldPhonePad(string input)
    {
        char[] temp_keymap;
        LinkedList<char> list = new LinkedList<char>();
        int press_count = 0;
        try
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '#') //If it #, end the loop
                {
                    //Console.WriteLine("Ended");
                    break;
                }

                else if (input[i] == '*')// If it *, remove latest char in list
                {

                    list.RemoveLast();
                }
                else if (input[i] == ' ')// If is space, reset the press count
                {
                    press_count = 0;
                }
                else if (input[i] == input[i + 1]) // if the next input is the same as current, input press_count + 1
                {
                    press_count++;
                }
                else if (input[i] != input[i + 1]) // if the next input is  not the same, find the key map from the current input and use press_count to find the char
                {
                    temp_keymap = DefineKeymap(input[i]);
                    list.AddLast(temp_keymap[press_count]);
                    press_count = 0;
                }
            }
        }
        catch (IndexOutOfRangeException Ex) // if there's no # at the end, find he key map from the current input and use press_count to find the char (or could just add Error: No # at the end        
        {
            temp_keymap = DefineKeymap(input[input.Length - 1]);
            list.AddLast(temp_keymap[press_count]);
        }
            //Console.WriteLine("total = " + press_count);
            String answer = string.Join("", list.ToArray());
            //Console.WriteLine("Hidden text = " + answer);

            return answer;
    }

    private static char[] DefineKeymap(char input) //find Key map
    {
        char[] Keymap = null;
        switch (input)
        {
            case '1':
                Keymap = new char[] { '?', '?', '?', '?' };
                break;
            case '2':
                Keymap = new char[] { 'A', 'B', 'C', '?' };
                break;
            case '3':
                Keymap = new char[] { 'D', 'E', 'F', '?' };
                break;
            case '4':
                Keymap = new char[] { 'G', 'H', 'I', '?' };
                break;
            case '5':
                Keymap = new char[] { 'J', 'K', 'L', '?' };
                break;
            case '6':
                Keymap = new char[] { 'M', 'N', 'O', '?' };
                break;
            case '7':
                Keymap = new char[] { 'P', 'Q', 'R', 'S' };
                break;
            case '8':
                Keymap = new char[] { 'T', 'U', 'V', '?' };
                break;
            case '9':
                Keymap = new char[] { 'W', 'X', 'Y', 'Z' };
                break;
            case '0':
                Keymap = new char[] { '?', '?', '?', '?' };
                break;
            case ' ':
                Keymap = new char[] { '?', '?', '?', '?' };
                break;
        }
        return Keymap;
    }
}
