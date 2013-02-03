using System;

class Guitar
{

    static void Print(int[,] a)
    {
#if DEBUG
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j]  + " ");
            }
            Console.WriteLine();
        }
#endif
    }
    static int HighestVolumeForLastSong(int[] volumes, int initial, int limit)
    {
        int[,] matrix = new int[volumes.Length + 1, limit + 1];

        matrix[0, initial] = 1;

        for (int rows = 1; rows < volumes.Length + 1; rows++)
        {
            for (int cols = 0; cols < limit + 1; cols++)
            {
                if (matrix[rows - 1, cols] == 1)
                {
                    int value = volumes[rows-1];
                    if (cols - value >= 0)
                    {
                        matrix[rows, cols - value] = 1;
                    }
                    if (value + cols <= limit)
                    {
                        matrix[rows, value + cols] = 1;
                    }
                }
            }
        }
        Print(matrix);
        for (int i = limit; i >= 0; i--)
        {
            if (matrix[volumes.Length, i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        string[] str = Console.ReadLine().Split(',');
        int[] volumes = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            volumes[i] = int.Parse(str[i]);
        }
        int initialVolume = int.Parse(Console.ReadLine());
        int volumeLimit = int.Parse(Console.ReadLine());

        Console.WriteLine(HighestVolumeForLastSong(volumes, initialVolume, volumeLimit));
    }
}
