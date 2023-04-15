namespace PodawanieLiczników
{
    public abstract class MediaBase
    {
        public abstract void MediaReader(float Licznik);
        public List<float> MediaList { get; set; }

    }
}
