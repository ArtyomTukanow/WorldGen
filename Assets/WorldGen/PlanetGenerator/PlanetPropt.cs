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
        public float HMin;
        /// <summary>
        /// Максимальная высота земли
        /// </summary>
        public float HMax;
        /// <summary>
        /// Уровень океана
        /// </summary>
        public float HOcean;
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