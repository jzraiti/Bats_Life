
using TMPro;
using UnityEngine;

public class BatFactScript : MonoBehaviour
{
    public TMP_Text BatFactText;

    string[] batFactTextArray = {
        "Bat Fact: There are over 1,400 species of bat",
        "Bat Fact: Bats are pollinators for many species of plants",
        "Bat Fact: Baby bats are called pups",
        "Bat Fact: Over half of all bat species in the USA are endangered",
        "Bat Fact: Blood is a vampire bat’s only source of food and water. Because of that they can’t go more than 2 days without feeding.",
        "Bat Fact: Bats have the capacity to eat insects equal to half their body weight every night. They can eat up to 1,200 mosquitoes in an hour.",
        "Bat Fact: Vampire bats will regurgitate blood and share it with other bats who are starving to help keep them alive.",
        "Bat Fact: Baby bats are also known to babble like human children.",
        "Bat Fact: The “giant golden-crowned flying fox” is a massive species of bats that has a five-foot wingspan",
        "Bat Fact: If there were no bats, the world would not have tequila. The agave plant from which tequila is made is pollinated by the bats.",
        "Bat Fact: Mexican free-tailed bats use sound to sabotage and jam the sensors of rival bats. Then they steal their prey",
        "Bat Fact: The largest bat colony in the world is in San Antonio, Texas with a population of over 15 million bats in one cave.",
        "Bat Fact: Millions of bats are dying from the “white-nose syndrome” in North America that the scientists have no idea how to treat",
        "Bat Fact: Red bats (Lasiurus spp) begin mating in flight",
        "Bat Fact: Mother bats use a version of baby talk to communicate with their pups and encourage vocal development",
        "Bat Fact: Vampire bats (Desmodus rotundus) have complex and rich social lives. They have even been observed adopting unrelated orphans",
        "Bat Fact: Bats are not rodents. They are more closely related to cats than rats",
        "Bat Fact: Bats can fly better than reindeer",
        "Bat Fact: Big Brown Bats (Epesticus fuscus) can go up to 2 1/2 hours without breathing during torpor",
        "Bat Fact: Fruit bats invert to go to the toilet! They will flip right way up, hanging by their thumbs, do their business, shake their legs and then revert",
        "Bat Fact: Fruit-eating bats have been recorded feeding on 1072 plant species and disperse seeds over larger distances than almost any other animal",
        "Bat Fact: Bats can swim",
        "Bat Fact: Pallid Bats are resistant to scorpion venom and actively hunt Arizona bark scorpions, which are the most venomous scorpions in North America",
        "Bat Fact: Ussurian tube-nosed bats (Murina ussuriensis) hibernate in the tunnels they build in the snow",
        "Bat Fact: In many areas, availability of suitable roosts is a limiting factor to bat distribution. A quality bat house may substitute for an old, dead tree or other crevice",
        "Bat Fact: Baby bats spend the first part of their lives clinging to their mother and wrapped in her wings. Rescued orphaned bats are wrapped in blankets to mimic this experience for them. They are also often given batcifiers (pacifiers)",
        "Bat Fact: The painted bat is a gorgeous shade of orange with black wings and orange along the fingers",
        "Bat Fact: Bats know the meaning of life, they're just not telling you",
        "Bat Fact: Dont look but theres a bat watching you right now",
        "Bat Fact: Bats Refuse to pay taxes",
        "Bat Fact: Today is a bats birthday",
        "Bat Fact: Most bats are staunch nudists",
        "Bat Fact: Most bats are very confused by baseball",
        "Bat Fact: Bats only eat locally sourced food",
        "Bat Fact: A bat has never cut off anyone in traffic ",
        "Bat Fact: Why do bats hate living on their own? They want to hang out with their friends.",
        "Bat Fact: What kind of bat can do a back flip? An acro-bat.",
        "Bat Fact: What's a vampire bat's favourite fruit? A neck-tarine.",
        "Bat Fact: What's the right way to hold a bat? Using the handle.",
        "Bat Fact: Why do bats hate living on their own? They want to hang out with their friends.",
        "Bat Fact: Bats can live more than 30 years.",
        "Bat Fact: Mexican free-tailed bat could reach speeds up to 100 mph",
        "Bat Fact: Bat droppings, called guano, are one of the richest fertilizers. Guano was Texas's largest mineral export before oil!",
        "Bat Fact: Bracken Cave, on the northern outskirts of San Antonio, is home to the world's largest bat colony, with more than 15 million Mexican free-tailed bats",
        "Bat Fact: Like cats, bats clean themselves",
        "Bat Fact: Humanos aren’t the only ones with belly buttons",
        "Bat Fact: Bats are the most biodiverse mammal with over 1,400 species",
        "Bat Fact: Bats have been around for around 50 million years ",
        "Bat Fact: Bats would never break up with you over text",
        "Bat Fact: Bats dont use single use plastics",
        "Bat Fact: Bats think you are perfect the way you are",
        "Bat Fact: Bats have never deforested the planet",
        "Bat Fact: The Zapotec tribe worshipped a bat god named Camazotz, the DEATH BAT, based on local leaf-nosed bats that lived in the sacred cenotes.",
        "bAt fAcT: iN bAt LaNgUaGe HuMaNs aRe CaLlEd #@$%^$#$"
    };
    // Start is called before the first frame update
    void Start()
    {
        string fact = batFactTextArray[Random.Range(0, batFactTextArray.Length)];
        BatFactText.SetText(fact);
    }
}
