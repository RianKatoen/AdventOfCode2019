namespace AOC2019.Modules.AstroidMaps
{
    public interface IAstroidMap
    {
        (int x, int y) Size { get; }
        bool Astroid((int x, int y) pos);
    }
}