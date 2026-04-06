namespace PE___Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Manually create nodes
            TalentTreeNode rootNode = new TalentTreeNode("Magic", true);
            TalentTreeNode fireball = new TalentTreeNode("Fireball", true);
            TalentTreeNode bigFireball = new TalentTreeNode("Crazy Big Fireball", false);
            TalentTreeNode miniFireball = new TalentTreeNode("1000 Tiny Fireballs", true);
            TalentTreeNode magicArrow = new TalentTreeNode("Magic Arrow", false);
            TalentTreeNode iceArrow = new TalentTreeNode("Ice Arrow", false);
            TalentTreeNode explodingArrow = new TalentTreeNode("Exploding Arrow", false);

            //Manually set their relationships
            rootNode.Left = fireball;
            rootNode.Right = magicArrow;
            fireball.Left = bigFireball;
            fireball.Right = miniFireball;
            magicArrow.Left = iceArrow;
            magicArrow.Right = explodingArrow;

            //Writing out abilities
            Console.WriteLine("Listing All Abilties: ");
            rootNode.ListAllAbilities();

            Console.WriteLine("\nListing All Learned Abilities:");
            rootNode.ListKnownAbilities();

            Console.WriteLine("\nListing All Abilities That Can Be Learned Next:");
            rootNode.ListPossibleAbilities();
        }
    }
}
