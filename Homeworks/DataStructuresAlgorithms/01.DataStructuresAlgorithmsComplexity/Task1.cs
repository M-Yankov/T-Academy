### Task 1

"I think its expected running time (algorithm complexity) will be O(n^2) in worst-case  because, for each element will perform another loop. Imagine that array is = [1, 2, 3, 4, 5, 6]. Get the first element then while first element is less than last one - it will pass each element. again."

### Task 2 

"imagine this situation"

int[,] twoDimensionalArray = 
    {
        {2,3,4,5},
        {4,1,2,3},
        {6,3,5,1},
        {4,4,6,7},
        {8,4,6,7},
        {2,4,0,7},
    };

int m = twoDimensionalArray.GetLength(0); // ↓
int n = twoDimensionalArray.GetLength(1); // →
"Answer must be O(m * n)"
"It will start checking from first column on each row, if meets the requirements from the condition operator it stats processing each element in the row till ends."


### Task 3

int [,] matrix = 
    {
        {1,3,4,4,1,4,6},
        {2,1,2,5,4,6,7},
        {0,9,5,5,3,5,7},
    }

"Only if the matrix is (n * n) then the algorithm will be executed correctly and the answer is O(n*n) or O(n^2). The example above will thrown an exception(n<m). Algorithm will pass through values 1,3,4,2,1,2,0,9,5 then IndexOutOfRangeException. On the example below the sequence must be like: 1,3,4 then the same exception (n>m). Consider that the if statement is not in the for loop. (For the third time i rewrite th task! :D )"

"Hints: 0 - first dimension ↓"
"       1 - second dimension →"

int [,] matrix = 
    {
        {1,3,4},
        {2,1,2},
        {0,9,5},
        {2,8,4},
        {5,8,1},
        {6,9,0}
    }
