namespace src.collisions
{
    public interface Collidable
    {
        float X { get; }
        float Y { get; }

        float Width { get; }
        float Height { get; }

        void OnCollide(Collidable collidable);
    }
}