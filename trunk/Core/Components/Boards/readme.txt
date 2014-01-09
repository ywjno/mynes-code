

To add new board, create new class then make it a subclass of Board.cs
Example:

class NewBoard: Board
{
......
}

Add the attribute "BoardName" to specify the board name and mapper #

The board you add MUST contain two constructors, one without parameters and the other one with parameters.

The parameters MUST be (byte[] chr, byte[] prg, byte[] trainer, bool isVram) otherwise the board will not initialize.
chr: the chr data dump as presented from rom (all banks in one array)
prg: the prg data dump as presented from rom (all banks in one array)
trainer: the trainer data dump as presented from rom (all banks in one array)
isVram: indicates of the rom contains no chr data ....

Example:
[BoardName("New Board", x)]// x is INES mapper number, this will help to detect the board later.
class NewBoard: Board
{
        public NewBoard()
            : base()
        { /*No need to write anything here !*/ }
        public NewBoard(byte[] chr, byte[] prg, byte[] trainer, bool isVram)//this MUST be like this.
            : base(chr, prg, trainer, isVram)
        { /*No need to write anything here !*/ }
}

If your board is a master board that other boards based on (like FFE.cs, this is a base board) then you MUST
mark the board class as abstract to avoid to be detected. Otherwise the boards manager will detect it and
consider it as board.... this may cause troubles.
See FFE.cs, it's abstract class so it's ignored by the manager while FFE_FE3xx.cs can be detected.

Never add duplicated board (e.g add two classes for the same mapper like adding UOROM and UNROM classes for the mapper 2). So
if the board behavior changed or there are more than board for the same mapper then you can implement this like it 
done in Mapper001_MMC1.cs

After adding the board class (anywhere you like in the project or seperated library) the BoardsManager class will detect
it automatically at application startup.