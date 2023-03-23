int InputNum(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine())!;
}

int[,] Create2DArray(int rows, int columns)
{
    return new int[rows, columns];
}

void Fill2DArray(int[,] array, int minValue, int maxValue)
{
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = rnd.Next(minValue, maxValue + 1);
}

string Print2DArray(int[,] array)
{
    string res = String.Empty;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            res += array[i, j];
            if (j != array.GetLength(1) - 1)
                res += "\t";
            else
                res += "\n";
        }
    Console.WriteLine();
    return res;
}

int[] MinIn2DArray(int[,] array)
{
    int minI = 0;
    int minJ = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            if (array[i, j] < array[minI, minJ])
            {
                minI = i;
                minJ = j;
            }
    return new int[] { minI, minJ };
}

int[,] DelRowColumn(int[,] array, int[] indexes)
{
    int row = indexes[0];
    int col = indexes[1];

    int[,] newArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    for (int i = 0, a = 0; i < array.GetLength(0); i++, a++)
    {
        if (i != row)
        {
            for (int j = 0, b = 0; j < array.GetLength(1); j++, b++)
            {
                if (j != col)
                    newArray[a, b] = array[i, j];
                else b--;
            }
        }
        else a--;
    }
    return newArray;
}


int numRows = InputNum("Input a number of rows: ");
int numCols = InputNum("Input a numbers of columns: ");
int[,] myArray = Create2DArray(numRows, numCols);
int min = InputNum("Input a min value: ");
int max = InputNum("Input a max value: ");
Fill2DArray(myArray, min, max);
string firstArr = Print2DArray(myArray);
Console.WriteLine(firstArr);

int[] minInd = MinIn2DArray(myArray);
int[,] littleArr = DelRowColumn(myArray, minInd);
string secondArr = Print2DArray(littleArr);
Console.WriteLine(secondArr);