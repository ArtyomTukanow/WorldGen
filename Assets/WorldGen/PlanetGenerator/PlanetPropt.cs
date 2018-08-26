namespace WorldGen
{
    public struct PlanetPropt
    {
        /// <summary>
        /// Сид карты
        /// </summary>
        public int Seed;
        /// <summary>
        /// Минимальная высота земли
        /// </summary>
        public float xMin;
        /// <summary>
        /// Максимальная высота земли
        /// </summary>
        public float xMax;
        /// <summary>
        /// Уровень океана
        /// </summary>
        public float xOcean;
        /// <summary>
        /// Размер Карты
        /// </summary>
        public int Size;
        /// <summary>
        /// Рельеф
        /// </summary>
        public float R;
    }
}