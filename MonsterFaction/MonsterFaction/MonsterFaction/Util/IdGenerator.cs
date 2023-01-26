namespace MonsterFaction.Util
{
    public static class IdGenerator
    {
        private static int nextObjectId = 1;
        public static int NextObjectId()
        {
            return nextObjectId++;
        }
    }
}
