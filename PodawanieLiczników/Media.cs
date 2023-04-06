namespace PodawanieLiczników
{
    public abstract class Media
    {
        public abstract void MediaReader(float Licznik);
        public List<float> MediaList { get; set; }

    }
}
