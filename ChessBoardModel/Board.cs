using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel
{
    public class Board
    {
        // the size of the board usually 8x8
        public int Size { get; set; }

        // 2d array of type cell
        public Cell[,] theGrid { get; set; }

        // constructor
        public Board(int s)
        {
            Size = s;

            // create a new 2d array of type cell
            theGrid = new Cell[Size, Size];

            // fill the 2d array with new cells, each with unique x and y coordinates
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell,int chessPiece)
        {
            // clear all previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNexMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            // find all legal moves and mark the cells as legal 
            switch (chessPiece)
            {
                // knight
                case 1:

                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNexMove = true;

                    if(isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNexMove = true;

                    if(isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNexMove = true;

                    if(isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNexMove = true;

                    if(isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNexMove = true;

                    if(isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNexMove = true;

                    if(isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNexMove = true;
                    
                    if(isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNexMove = true;

                    break;

                // king
                case 2:

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNexMove = true;

                    break;

                // rook
                case 3:

                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNexMove = true;
                    }

                    break;

                // bishop
                case 4:

                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNexMove = true;
                    }

                    break;

                // queen
                case 5:

                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNexMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNexMove = true;
                    }

                    break;

                // pawn
                case 6:

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber].LegalNexMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNexMove = true;

                    break;

                default:

                    break;

            }

            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private bool isSafe(int v1, int v2)
        {
            if (v1 < Size)
                if (v1 > 0)
                {
                    if (v2 < Size)
                    {
                        if (v2 > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            else
            {
                return false;
            }
        }
    }
}
