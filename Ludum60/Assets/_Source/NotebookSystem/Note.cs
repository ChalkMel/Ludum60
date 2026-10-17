namespace _Source.NotebookSystem
{
  public readonly struct Note
  {
    public readonly object Owner;
    public readonly string Text;

    public Note(object owner, string text) { Owner = owner; Text = text; }
  }
}