using System;

class Sudoku
{
    
    public CustomNode[,] sudoku;

    public Children children;

    public Sudoku parent;

    public Sudoku(CustomNode[,] sudoku)
    {
        this.sudoku = sudoku;
        this.children = new Children();
    }

}