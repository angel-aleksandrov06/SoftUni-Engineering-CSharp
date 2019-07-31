using System;
using System.Text;
using System.Linq;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var splitedInput = input.Split(":");
                var artis = splitedInput[0];
                var song = splitedInput[1];

                var isArtistValid = true;
                var isSongValid = true;

                if (Char.IsUpper(artis[0]))
                {
                    for (int i = 1; i < artis.Length; i++)
                    {
                        if (!char.IsLower(artis[i]) && artis[i] != '\'' && artis[i] != ' ')
                        {
                            isArtistValid = false;
                            break;
                        }
                    }
                }
                else
                {
                    isArtistValid = false;
                }

                if (isArtistValid)
                {
                    for (int i = 0; i < song.Length; i++)
                    {
                        if (!Char.IsUpper(song[i]) && song[i] != ' ')
                        {
                            isSongValid = false;
                        }
                    }
                }

                if (isArtistValid && isSongValid)
                {
                    var key = artis.Length;

                    var sb = new StringBuilder();

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == ' ' || input[i] == '\'')
                        {
                            sb.Append(input[i].ToString());
                        }
                        else if (input[i] == ':')
                        {
                            sb.Append("@");
                        }
                        else
                        {
                            var newSymbol = (char)(input[i] + key);

                            if (char.IsUpper(input[i]) && newSymbol > 'Z')
                            {
                                newSymbol = (char)(newSymbol - 26);
                            }
                            else if (char.IsLower(input[i]) && newSymbol > 'z')
                            {
                                newSymbol = (char)(newSymbol - 26);
                            }
                            sb.Append(newSymbol);
                        }
                    }
                    Console.WriteLine($"Successful encryption: {sb}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
