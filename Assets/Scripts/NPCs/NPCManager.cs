﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NPCManager : MonoBehaviour {
    public UnityEvent dayFinished = new UnityEvent();
    public uint numDays = Config.numDays;
    private List<string> maleFirstNames = new List<string> { "Jacob", "Michael", "Matthew", "Joshua", "Christopher", "Nicholas", "Andrew", "Joseph", "Daniel", "Tyler", "William", "Brandon", "Ryan", "John", "Zachary", "David", "Anthony", "James", "Justin", "Alexander", "Jonathan", "Christian", "Austin", "Dylan", "Ethan", "Benjamin", "Noah", "Samuel", "Robert", "Nathan", "Cameron", "Kevin", "Thomas", "Jose", "Hunter", "Jordan", "Kyle", "Caleb", "Jason", "Logan", "Aaron", "Eric", "Brian", "Gabriel", "Adam", "Jack", "Isaiah", "Juan", "Luis", "Connor", "Charles", "Elijah", "Isaac", "Steven", "Evan", "Jared", "Sean", "Timothy", "Luke", "Cody", "Nathaniel", "Alex", "Seth", "Mason", "Richard", "Carlos", "Angel", "Patrick", "Devin", "Bryan", "Cole", "Jackson", "Ian", "Garrett", "Trevor", "Jesus", "Chase", "Adrian", "Mark", "Blake", "Sebastian", "Antonio", "Lucas", "Jeremy", "Gavin", "Miguel", "Julian", "Dakota", "Alejandro", "Jesse", "Dalton", "Bryce", "Tanner", "Kenneth", "Stephen", "Jake", "Victor", "Spencer", "Marcus", "Paul", "Brendan", "Jeremiah", "Xavier", "Jeffrey", "Tristan", "Jalen", "Jorge", "Edward", "Riley", "Colton", "Wyatt", "Joel", "Maxwell", "Aidan", "Travis", "Shane", "Colin", "Dominic", "Carson", "Vincent", "Derek", "Oscar", "Grant", "Eduardo", "Peter", "Henry", "Parker", "Collin", "Hayden", "George", "Bradley", "Mitchell", "Devon", "Ricardo", "Shawn", "Taylor", "Nicolas", "Gregory", "Francisco", "Liam", "Kaleb", "Preston", "Erik", "Alexis", "Owen", "Omar", "Diego", "Dustin", "Corey", "Fernando", "Clayton", "Carter", "Ivan", "Jaden", "Javier", "Alec", "Johnathan", "Scott", "Manuel", "Cristian", "Alan", "Raymond", "Brett", "Max", "Andres", "Gage", "Mario", "Dawson", "Dillon", "Cesar", "Wesley", "Levi", "Jakob", "Chandler", "Martin", "Malik", "Edgar", "Sergio", "Trenton", "Josiah", "Nolan", "Marco", "Peyton", "Harrison", "Hector", "Micah", "Roberto", "Drew", "Brady", "Erick", "Conner", "Jonah", "Casey", "Jayden", "Edwin", "Emmanuel", "Andre", "Phillip", "Brayden", "Landon", "Giovanni", "Bailey", "Ronald", "Braden", "Damian", "Donovan", "Ruben", "Frank", "Gerardo", "Pedro", "Andy", "Chance", "Abraham", "Calvin", "Trey", "Cade", "Donald", "Derrick", "Payton", "Darius", "Enrique", "Keith", "Raul", "Jaylen", "Troy", "Jonathon", "Cory", "Marc", "Eli", "Skyler", "Rafael", "Trent", "Griffin", "Colby", "Johnny", "Chad", "Armando", "Kobe", "Caden", "Marcos", "Cooper", "Elias", "Brenden", "Israel", "Avery", "Zane", "Dante", "Josue", "Zackary", "Allen", "Mathew", "Dennis", "Leonardo", "Ashton", "Philip", "Julio", "Miles", "Damien", "Ty", "Gustavo", "Drake", "Jaime", "Simon", "Jerry", "Curtis", "Kameron", "Lance", "Brock", "Bryson", "Alberto", "Dominick", "Jimmy", "Kaden", "Douglas", "Gary", "Brennan", "Zachery", "Randy", "Louis", "Larry", "Nickolas", "Albert", "Tony", "Fabian", "Keegan", "Saul", "Danny", "Tucker", "Myles", "Damon", "Arturo", "Corbin", "Deandre", "Ricky", "Kristopher", "Lane", "Pablo", "Darren", "Jarrett", "Zion", "Alfredo", "Micheal", "Angelo", "Carl", "Oliver", "Kyler", "Tommy", "Walter", "Dallas", "Jace", "Quinn", "Theodore", "Grayson", "Lorenzo", "Joe", "Arthur", "Bryant", "Roman", "Brent", "Russell", "Ramon", "Lawrence", "Moises", "Aiden", "Quentin", "Jay", "Tyrese", "Tristen", "Emanuel", "Salvador", "Terry", "Morgan", "Jeffery", "Esteban", "Tyson", "Braxton", "Branden", "Marvin", "Brody", "Craig", "Ismael", "Rodney", "Isiah", "Marshall", "Maurice", "Ernesto", "Emilio", "Brendon", "Kody", "Eddie", "Malachi", "Abel", "Keaton", "Jon", "Shaun", "Skylar", "Ezekiel", "Nikolas", "Santiago", "Kendall", "Axel", "Camden", "Trevon", "Bobby", "Conor", "Jamal", "Lukas", "Malcolm", "Zackery", "Jayson", "Javon", "Roger", "Reginald", "Zachariah", "Desmond", "Felix", "Johnathon", "Dean", "Quinton", "Ali", "Davis", "Gerald", "Rodrigo", "Demetrius", "Billy", "Rene", "Reece", "Kelvin", "Leo", "Justice", "Chris", "Guillermo", "Kevon", "Steve", "Frederick", "Clay", "Weston", "Dorian", "Hugo", "Roy", "Orlando", "Terrance", "Kai", "Khalil", "Graham", "Noel", "Willie", "Nathanael", "Terrell", "Tyrone", "Camron", "Mauricio", "Amir", "Nelson", "Darian", "Jarod", "Kade", "Reese", "Kristian", "Garret", "Rodolfo", "Marquis", "Dane", "Felipe", "Todd", "Elian", "Walker", "Mateo", "Jaylon", "Kenny", "Ezra", "Bruce", "Damion", "Ross", "Francis", "Tate", "Reid", "Warren", "Byron", "Randall", "Bennett", "Jermaine", "Triston", "Harley", "Jaquan", "Jessie", "Duncan", "Franklin", "Reed", "Charlie", "Blaine", "Braeden", "Holden", "Ahmad", "Issac", "Melvin", "Moses", "Kendrick", "Sawyer", "Solomon", "Sam", "Alvin", "Cedric", "Jaylin", "Jordon", "Mohammad", "Beau", "Elliot", "Lee", "Darrell", "Jarred", "Mohamed", "Davion", "Wade", "Tomas", "Uriel", "Jaxon", "Deven", "Maximilian", "Gilberto", "Rogelio", "Ronnie", "Julius", "Allan", "Joey", "Brayan", "Deshawn", "Terrence", "Noe", "Alfonso", "Ahmed", "Tyree", "Tyrell", "Jerome", "Devan", "Neil", "Ramiro", "Pierce", "Davon", "Devonte", "Leon", "Jamie", "Adan", "Eugene", "Stanley", "Wayne", "Marlon", "Leonard", "Quincy", "Will", "Alvaro", "Ernest", "Harry", "Jonas", "Addison", "Ray", "Alonzo", "Jadon", "Keyshawn", "Rolando", "Mohammed", "Tristin", "Donte", "Leonel", "Dominique", "Wilson", "Gilbert", "Kieran", "Coby", "Dangelo", "Colten", "Keenan", "Koby", "Jarrod", "Dale", "Toby", "Dwayne", "Harold", "Elliott", "Osvaldo", "Cyrus", "Kolby", "Sage", "Coleman", "Declan", "Adolfo", "Ariel", "Brennen", "Darryl", "Trace", "Efrain", "Orion", "Rudy", "Shamar", "Keshawn", "Ulises", "Darien", "Braydon", "Ben", "Vicente", "Nasir", "Dayton", "Joaquin", "Karl", "Dandre", "Isaias", "Cullen", "Rylan", "Sterling", "Quintin", "Stefan", "Brice", "Lewis", "Gunnar", "Humberto", "Alfred", "Nigel", "Asher", "Agustin", "Daquan", "Easton", "Salvatore", "Jaron", "Nathanial", "Ralph", "Everett", "Tobias", "Hudson", "Marquise", "Glenn", "Antoine", "Jasper", "Elvis", "Kane", "Sidney", "Aron", "Ezequiel", "Tylor", "Dashawn", "Devyn", "Mike", "Silas", "Jaiden", "Jayce", "Deonte", "Romeo", "Deon", "Cristopher", "Freddy", "Kurt", "Kolton", "River", "August", "Clarence", "Roderick", "Derick", "Jamar", "Raphael", "Kareem", "Muhammad", "Rohan", "Demarcus", "Sheldon", "Cayden", "Markus", "Luca", "Tre", "Jean", "Titus", "Jamison", "Rory", "Brad", "Clinton", "Jaylan", "Emiliano", "Jevon", "Julien", "Lamar", "Alonso", "Cordell", "Gordon", "Ignacio", "Cruz", "Jett", "Keon", "Baby", "Rashad", "Tariq", "Armani", "Milton", "Deangelo", "Geoffrey", "Elisha", "Moshe", "Asa", "Bernard", "Bret", "Darion", "Darnell", "Izaiah", "Irvin", "Jairo", "Howard", "Aldo", "Norman", "Zechariah", "Ayden", "Garrison", "Stuart", "Travon", "Kellen", "Shemar", "Dillan", "Junior", "Darrius", "Rhett", "Barry", "Kamron", "Jude", "Rigoberto", "Amari", "Jovan", "Perry", "Octavio", "Kole", "Misael", "Hassan", "Jaren", "Latrell", "Roland", "Quinten", "German", "Ibrahim", "Justus", "Gonzalo", "Nehemiah", "Forrest", "Mackenzie", "Talon", "Anton", "Chaz", "Leroy", "Guadalupe", "Winston", "Antwan", "Austen", "Brooks", "Conrad", "Greyson", "Dion", "Lincoln", "Earl", "Jaydon", "Landen", "Gunner", "Brenton", "Jefferson", "Fredrick", "Kurtis", "Maximillian", "Stephan", "Stone", "Shannon", "Shayne", "Stephon", "Karson", "Nestor", "Tristian", "Frankie", "Gianni", "Keagan", "Dimitri", "Kory", "Zakary", "Daryl", "Donavan", "Draven", "Jameson", "Clifton", "Emmett", "Cortez", "Destin", "Jamari", "Dallin", "Estevan", "Grady", "Davin", "Santos", "Marcel", "Carlton", "Dylon", "Mitchel", "Clifford", "Syed", "Dexter", "Adonis", "Keyon", "Reynaldo", "Devante", "Arnold", "Clark", "Kasey", "Sammy", "Thaddeus", "Glen", "Jarvis", "Nick", "Ulysses", "Garett", "Infant", "Keanu", "Kenyon", "Dwight", "Kent", "Denzel", "Lamont", "Houston", "Layne", "Darin", "Jorden", "Anderson", "Kayden", "Khalid", "Antony", "Deondre", "Ellis", "Marquez", "Ari", "Cornelius", "Reuben", "Austyn", "Brycen", "Abram", "Remington", "Braedon", "Hamza", "Ryder", "Zaire", "Terence", "Guy", "Jamel", "Kelly", "Porter", "Tevin", "Alexandro", "Dario", "Jordy", "Trever", "Jackie", "Judah", "Keven", "Raymundo", "Cristobal", "Josef", "Paris", "Colt", "Giancarlo", "Rahul", "Savion", "Deshaun", "Josh", "Korey", "Gerard", "Jacoby", "Lonnie", "Reilly", "Seamus", "Don", "Giovanny", "Jamil", "Kristofer", "Samir", "Vernon", "Benny", "Dominik", "Finn", "Jan", "Kaiden", "Cale", "Irving", "Jaxson", "Marcelo", "Nico", "Rashawn", "Aubrey", "Gaven", "Jabari", "Sincere", "Kirk", "Maximus", "Mikel", "Davonte", "Elmer", "Heath", "Justyn", "Kadin", "Alden", "Kelton", "Brandan", "Courtney", "Camren", "Dewayne", "Duane", "Maverick", "Darrin", "Darrion", "Nikhil", "Sonny", "Abdullah", "Chaim", "Nathen", "Xzavier", "Bronson", "Efren", "Jovani", "Phoenix", "Reagan", "Aden", "Blaze", "Gideon", "Luciano", "Royce", "Tyrek", "Tyshawn", "Deontae", "Fidel", "Gaige", "Neal", "Ronaldo", "Matteo", "Prince", "Rickey", "Deion", "Denver", "Benito", "London", "Samson", "Bernardo", "Raven", "Simeon", "Turner", "Carlo", "Gino", "Johan", "Rocky", "Ryley", "Domenic", "Hugh", "Trystan", "Emerson", "Joan", "Trevion", "Heriberto", "Marques", "Raheem", "Tyreek", "Vaughn", "Clint", "Nash", "Mariano", "Myron", "Ladarius", "Lloyd", "Omari", "Pierre", "Keshaun", "Rick", "Xander", "Amos", "Eliseo", "Jeff", "Bradly", "Freddie", "Kavon", "Mekhi", "Sabastian", "Shea", "Dan", "Adrien", "Alessandro", "Blaise", "Isai", "Kian", "Maximiliano", "Paxton", "Rasheed", "Brodie", "Donnie", "Isidro", "Jaeden", "Javion", "Jimmie", "Johnnie", "Kennedy", "Tyrique", "Andreas", "Augustus", "Jalon", "Jamir", "Valentin", "Korbin", "Lawson", "Maxim", "Fred", "Herbert", "Bruno", "Donavon", "Javonte", "Ean", "Kamren", "Rowan", "Alek", "Brandyn", "Demarco", "Harvey", "Hernan", "Alexzander", "Bo", "Branson", "Brennon", "Genaro", "Jamarcus", "Aric", "Barrett", "Rey", "Braiden", "Brant", "Dontae", "Jovany", "Kale", "Nicklaus", "Zander", "Dillion", "Donnell", "Kylan", "Treyvon", "Vincenzo", "Dayne", "Francesco", "Isaak" },
    femaleFirstNames = new List<string> { "Emily", "Hannah", "Madison", "Ashley", "Sarah", "Alexis", "Samantha", "Jessica", "Elizabeth", "Taylor", "Lauren", "Alyssa", "Kayla", "Abigail", "Brianna", "Olivia", "Emma", "Megan", "Grace", "Victoria", "Rachel", "Anna", "Sydney", "Destiny", "Morgan", "Jennifer", "Jasmine", "Haley", "Julia", "Kaitlyn", "Nicole", "Amanda", "Katherine", "Natalie", "Hailey", "Alexandra", "Savannah", "Chloe", "Rebecca", "Stephanie", "Maria", "Sophia", "Mackenzie", "Allison", "Isabella", "Mary", "Amber", "Danielle", "Gabrielle", "Jordan", "Brooke", "Michelle", "Sierra", "Katelyn", "Andrea", "Madeline", "Sara", "Kimberly", "Courtney", "Erin", "Brittany", "Vanessa", "Jenna", "Jacqueline", "Caroline", "Faith", "Makayla", "Bailey", "Paige", "Shelby", "Melissa", "Kaylee", "Christina", "Trinity", "Mariah", "Caitlin", "Autumn", "Marissa", "Angela", "Breanna", "Catherine", "Zoe", "Briana", "Jada", "Laura", "Claire", "Alexa", "Kelsey", "Kathryn", "Leslie", "Alexandria", "Sabrina", "Mia", "Isabel", "Molly", "Katie", "Leah", "Gabriella", "Cheyenne", "Cassandra", "Tiffany", "Erica", "Lindsey", "Kylie", "Amy", "Diana", "Cassidy", "Mikayla", "Ariana", "Margaret", "Kelly", "Miranda", "Maya", "Melanie", "Audrey", "Jade", "Gabriela", "Caitlyn", "Angel", "Jillian", "Alicia", "Jocelyn", "Erika", "Lily", "Heather", "Madelyn", "Adriana", "Arianna", "Lillian", "Kiara", "Riley", "Crystal", "Mckenzie", "Meghan", "Skylar", "Ana", "Britney", "Angelica", "Kennedy", "Chelsea", "Daisy", "Kristen", "Veronica", "Isabelle", "Summer", "Hope", "Brittney", "Lydia", "Hayley", "Evelyn", "Bethany", "Shannon", "Karen", "Michaela", "Jamie", "Daniela", "Angelina", "Kaitlin", "Karina", "Sophie", "Sofia", "Diamond", "Payton", "Cynthia", "Alexia", "Valerie", "Monica", "Peyton", "Carly", "Bianca", "Hanna", "Brenda", "Rebekah", "Alejandra", "Mya", "Avery", "Brooklyn", "Ashlyn", "Lindsay", "Ava", "Desiree", "Alondra", "Camryn", "Ariel", "Naomi", "Jordyn", "Kendra", "Mckenna", "Holly", "Julie", "Kendall", "Kara", "Jasmin", "Selena", "Esmeralda", "Amaya", "Kylee", "Maggie", "Makenzie", "Claudia", "Kyra", "Cameron", "Karla", "Kathleen", "Abby", "Delaney", "Amelia", "Casey", "Serena", "Savanna", "Aaliyah", "Giselle", "Mallory", "April", "Adrianna", "Raven", "Christine", "Kristina", "Nina", "Asia", "Natalia", "Valeria", "Aubrey", "Lauryn", "Kate", "Patricia", "Jazmin", "Rachael", "Katelynn", "Cierra", "Alison", "Nancy", "Macy", "Elena", "Kyla", "Katrina", "Jazmine", "Joanna", "Tara", "Gianna", "Juliana", "Fatima", "Sadie", "Allyson", "Gracie", "Guadalupe", "Genesis", "Yesenia", "Julianna", "Skyler", "Tatiana", "Alexus", "Alana", "Elise", "Kirsten", "Nadia", "Sandra", "Ruby", "Dominique", "Haylee", "Jayla", "Tori", "Cindy", "Ella", "Sidney", "Tessa", "Carolina", "Jaqueline", "Camille", "Carmen", "Whitney", "Vivian", "Priscilla", "Bridget", "Celeste", "Kiana", "Makenna", "Alissa", "Madeleine", "Miriam", "Natasha", "Ciara", "Cecilia", "Kassandra", "Mercedes", "Reagan", "Aliyah", "Josephine", "Charlotte", "Rylee", "Shania", "Kira", "Meredith", "Eva", "Lisa", "Dakota", "Hallie", "Anne", "Rose", "Liliana", "Kristin", "Deanna", "Imani", "Marisa", "Kailey", "Annie", "Nia", "Carolyn", "Anastasia", "Brenna", "Dana", "Shayla", "Ashlee", "Kassidy", "Alaina", "Wendy", "Rosa", "Logan", "Tabitha", "Paola", "Callie", "Addison", "Lucy", "Gillian", "Clarissa", "Esther", "Destinee", "Josie", "Denise", "Katlyn", "Mariana", "Bryanna", "Emilee", "Georgia", "Kamryn", "Deja", "Ashleigh", "Cristina", "Ruth", "Baylee", "Heaven", "Raquel", "Monique", "Teresa", "Helen", "Krystal", "Tiana", "Cassie", "Kayleigh", "Marina", "Ivy", "Heidi", "Clara", "Ashton", "Meagan", "Gina", "Linda", "Gloria", "Jacquelyn", "Ellie", "Jenny", "Renee", "Daniella", "Lizbeth", "Anahi", "Virginia", "Gisselle", "Kaitlynn", "Julissa", "Cheyanne", "Lacey", "Haleigh", "Marie", "Martha", "Eleanor", "Kierra", "Tiara", "Talia", "Eliza", "Kaylie", "Mikaela", "Harley", "Jaden", "Hailee", "Madalyn", "Kasey", "Ashlynn", "Brandi", "Lesly", "Elisabeth", "Allie", "Viviana", "Cara", "Marisol", "India", "Litzy", "Tatyana", "Melody", "Jessie", "Brandy", "Alisha", "Hunter", "Noelle", "Carla", "Francesca", "Tia", "Layla", "Krista", "Zoey", "Carley", "Janet", "Carissa", "Iris", "Susan", "Kaleigh", "Tyler", "Tamara", "Theresa", "Yasmine", "Tatum", "Sharon", "Alice", "Yasmin", "Tamia", "Abbey", "Alayna", "Kali", "Lilly", "Bailee", "Lesley", "Mckayla", "Ayanna", "Serenity", "Karissa", "Precious", "Jane", "Maddison", "Jayda", "Lexi", "Kelsie", "Phoebe", "Halle", "Kiersten", "Kiera", "Tyra", "Annika", "Felicity", "Taryn", "Kaylin", "Ellen", "Kiley", "Jaclyn", "Rhiannon", "Madisyn", "Colleen", "Joy", "Charity", "Pamela", "Tania", "Fiona", "Kaila", "Irene", "Alyson", "Annabelle", "Emely", "Angelique", "Alina", "Johanna", "Regan", "Janelle", "Janae", "Madyson", "Paris", "Justine", "Chelsey", "Sasha", "Paulina", "Mayra", "Zaria", "Skye", "Cora", "Brisa", "Emilie", "Felicia", "Tianna", "Larissa", "Macie", "Aurora", "Sage", "Lucia", "Alma", "Chasity", "Ann", "Deborah", "Nichole", "Jayden", "Alanna", "Malia", "Carlie", "Angie", "Nora", "Sylvia", "Carrie", "Kailee", "Elaina", "Sonia", "Barbara", "Kenya", "Genevieve", "Piper", "Marilyn", "Amari", "Macey", "Marlene", "Julianne", "Tayler", "Brooklynn", "Lorena", "Perla", "Elisa", "Eden", "Kaley", "Leilani", "Miracle", "Devin", "Aileen", "Chyna", "Esperanza", "Athena", "Regina", "Adrienne", "Shyanne", "Luz", "Tierra", "Clare", "Cristal", "Eliana", "Kelli", "Eve", "Sydnee", "Madelynn", "Breana", "Melina", "Arielle", "Justice", "Toni", "Corinne", "Abbigail", "Maia", "Tess", "Ciera", "Ebony", "Lena", "Maritza", "Lexie", "Isis", "Aimee", "Leticia", "Sydni", "Sarai", "Halie", "Alivia", "Destiney", "Laurel", "Edith", "Fernanda", "Carina", "Amya", "Destini", "Aspen", "Nathalie", "Paula", "Tanya", "Tina", "Frances", "Christian", "Elaine", "Shayna", "Aniya", "Mollie", "Ryan", "Essence", "Simone", "Kyleigh", "Nikki", "Anya", "Reyna", "Savanah", "Kaylyn", "Nicolette", "Abbie", "Montana", "Kailyn", "Itzel", "Leila", "Cayla", "Stacy", "Robin", "Araceli", "Candace", "Dulce", "Noemi", "Aleah", "Jewel", "Ally", "Mara", "Nayeli", "Karlee", "Keely", "Micaela", "Alisa", "Desirae", "Leanna", "Antonia", "Judith", "Brynn", "Jaelyn", "Raegan", "Katelin", "Sienna", "Celia", "Yvette", "Juliet", "Anika", "Emilia", "Calista", "Carlee", "Eileen", "Kianna", "Thalia", "Rylie", "Rosemary", "Daphne", "Kacie", "Karli", "Micah", "Ericka", "Jadyn", "Lyndsey", "Hana", "Haylie", "Madilyn", "Blanca", "Laila", "Kayley", "Katarina", "Kellie", "Maribel", "Sandy", "Joselyn", "Kaelyn", "Kathy", "Madisen", "Carson", "Margarita", "Stella", "Juliette", "Devon", "Bria", "Camila", "Donna", "Helena", "Lea", "Jazlyn", "Jazmyn", "Skyla", "Christy", "Joyce", "Katharine", "Karlie", "Lexus", "Alessandra", "Salma", "Delilah", "Moriah", "Beatriz", "Celine", "Lizeth", "Brianne", "Kourtney", "Sydnie", "Mariam", "Stacey", "Robyn", "Hayden", "Janessa", "Kenzie", "Jalyn", "Sheila", "Meaghan", "Aisha", "Shawna", "Jaida", "Estrella", "Marley", "Melinda", "Ayana", "Karly", "Devyn", "Nataly", "Loren", "Rosalinda", "Brielle", "Laney", "Sally", "Lizette", "Tracy", "Lilian", "Rebeca", "Chandler", "Jenifer", "Diane", "Valentina", "America", "Candice", "Abigayle", "Susana", "Aliya", "Casandra", "Harmony", "Jacey", "Alena", "Aylin", "Carol", "Shea", "Stephany", "Aniyah", "Zoie", "Jackeline", "Alia", "Gwendolyn", "Savana", "Damaris", "Violet", "Marian", "Anita", "Jaime", "Alexandrea", "Dorothy", "Jaiden", "Kristine", "Carli", "Gretchen", "Janice", "Annette", "Mariela", "Amani", "Maura", "Bella", "Kaylynn", "Lila", "Armani", "Anissa", "Aubree", "Kelsi", "Greta", "Kaya", "Kayli", "Lillie", "Willow", "Ansley", "Catalina", "Lia", "Maci", "Mattie", "Celina", "Shyann", "Alysa", "Jaquelin", "Quinn", "Cecelia", "Kallie", "Kasandra", "Chaya", "Hailie", "Haven", "Maegan", "Maeve", "Rocio", "Yolanda", "Christa", "Gabriel", "Kari", "Noelia", "Jeanette", "Kaylah", "Marianna", "Nya", "Kennedi", "Presley", "Yadira", "Elissa", "Nyah", "Shaina", "Reilly", "Alize", "Amara", "Arlene", "Izabella", "Lyric", "Aiyana", "Allyssa", "Drew", "Rachelle", "Adeline", "Jacklyn", "Jesse", "Citlalli", "Giovanna", "Liana", "Brook", "Graciela", "Princess", "Selina", "Chanel", "Elyse", "Cali", "Berenice", "Iliana", "Jolie", "Annalise", "Caitlynn", "Christiana", "Sarina", "Cortney", "Darlene", "Dasia", "London", "Yvonne", "Karley", "Shaylee", "Kristy", "Myah", "Ryleigh", "Amira", "Juanita", "Dariana", "Teagan", "Kiarra", "Ryann", "Yamilet", "Sheridan", "Alexys", "Baby", "Kacey", "Shakira", "Dianna", "Lara", "Isabela", "Reina", "Shirley", "Jaycee", "Silvia", "Tatianna", "Eryn", "Ingrid", "Keara", "Randi", "Reanna", "Kalyn", "Lisette", "Monserrat", "Abril", "Ivana", "Lori", "Darby", "Kaela", "Maranda", "Parker", "Darian", "Jasmyn", "Jaylin", "Katia", "Ayla", "Bridgette", "Elyssa", "Hillary", "Kinsey", "Yazmin", "Caleigh", "Rita", "Asha", "Dayana", "Nikita", "Chantel", "Reese", "Stefanie", "Nadine", "Samara", "Unique", "Michele", "Sonya", "Hazel", "Patience", "Cielo", "Mireya", "Paloma", "Aryanna", "Magdalena", "Anaya", "Dallas", "Joelle", "Norma", "Arely", "Kaia", "Misty", "Taya", "Deasia", "Trisha", "Elsa", "Joana", "Alysha", "Aracely", "Bryana", "Dawn", "Alex", "Brionna", "Katerina", "Ali", "Bonnie", "Hadley", "Martina", "Maryam", "Jazmyne", "Shaniya", "Alycia", "Dejah", "Emmalee", "Estefania", "Jakayla", "Lilliana", "Nyasia", "Anjali", "Daisha", "Myra", "Amiya", "Belen", "Jana", "Aja", "Saige", "Annabel", "Scarlett", "Destany", "Joanne", "Aliza", "Ashly", "Cydney", "Fabiola", "Gia", "Keira", "Roxanne", "Kaci", "Abigale", "Abagail", "Janiya", "Odalys", "Aria", "Daija", "Delia", "Kameron", "Raina", "Ashtyn", "Dayna", "Katy", "Lourdes", "Emerald", "Kirstin", "Marlee", "Neha", "Beatrice", "Blair", "Kori", "Luisa", "Yasmeen", "Annamarie", "Breonna", "Jena", "Leann", "Rhianna", "Yessenia", "Breanne", "Katlynn", "Laisha", "Mandy", "Amina", "Jailyn", "Jayde", "Jill", "Kaylan", "Kenna", "Antoinette", "Rayna", "Sky", "Iyana", "Keeley", "Kenia", "Maiya", "Melisa", "Adrian", "Marlen" },
    lastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White", "Lopez", "Lee", "Gonzalez", "Harris", "Clark", "Lewis", "Robinson", "Walker", "Perez", "Hall", "Young", "Allen", "Sanchez", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill", "Ramirez", "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans", "Turner", "Torres", "Parker", "Collins", "Edwards", "Stewart", "Flores", "Morris", "Nguyen", "Murphy", "Rivera", "Cook", "Rogers", "Morgan", "Peterson", "Cooper", "Reed", "Bailey", "Bell", "Gomez", "Kelly", "Howard", "Ward", "Cox", "Diaz", "Richardson", "Wood", "Watson", "Brooks", "Bennett", "Gray", "James", "Reyes", "Cruz", "Hughes", "Price", "Myers", "Long", "Foster", "Sanders", "Ross", "Morales", "Powell", "Sullivan", "Russell", "Ortiz", "Jenkins", "Gutierrez", "Perry", "Butler", "Barnes", "Fisher", "Henderson", "Coleman", "Simmons", "Patterson", "Jordan", "Reynolds", "Hamilton", "Graham", "Kim", "Gonzales", "Alexander", "Ramos", "Wallace", "Griffin", "West", "Cole", "Hayes", "Chavez", "Gibson", "Bryant", "Ellis", "Stevens", "Murray", "Ford", "Marshall", "Owens", "Mcdonald", "Harrison", "Ruiz", "Kennedy", "Wells", "Alvarez", "Woods", "Mendoza", "Castillo", "Olson", "Webb", "Washington", "Tucker", "Freeman", "Burns", "Henry", "Vasquez", "Snyder", "Simpson", "Crawford", "Jimenez", "Porter", "Mason", "Shaw", "Gordon", "Wagner", "Hunter", "Romero", "Hicks", "Dixon", "Hunt", "Palmer", "Robertson", "Black", "Holmes", "Stone", "Meyer", "Boyd", "Mills", "Warren", "Fox", "Rose", "Rice", "Moreno", "Schmidt", "Patel", "Ferguson", "Nichols", "Herrera", "Medina", "Ryan", "Fernandez", "Weaver", "Daniels", "Stephens", "Gardner", "Payne", "Kelley", "Dunn", "Pierce", "Arnold", "Tran", "Spencer", "Peters", "Hawkins", "Grant", "Hansen", "Castro", "Hoffman", "Hart", "Elliott", "Cunningham", "Knight", "Bradley", "Carroll", "Hudson", "Duncan", "Armstrong", "Berry", "Andrews", "Johnston", "Ray", "Lane", "Riley", "Carpenter", "Perkins", "Aguilar", "Silva", "Richards", "Willis", "Matthews", "Chapman", "Lawrence", "Garza", "Vargas", "Watkins", "Wheeler", "Larson", "Carlson", "Harper", "George", "Greene", "Burke", "Guzman", "Morrison", "Munoz", "Jacobs", "Obrien", "Lawson", "Franklin", "Lynch", "Bishop", "Carr", "Salazar", "Austin", "Mendez", "Gilbert", "Jensen", "Williamson", "Montgomery", "Harvey", "Oliver", "Howell", "Dean", "Hanson", "Weber", "Garrett", "Sims", "Burton", "Fuller", "Soto", "Mccoy", "Welch", "Chen", "Schultz", "Walters", "Reid", "Fields", "Walsh", "Little", "Fowler", "Bowman", "Davidson", "May", "Day", "Schneider", "Newman", "Brewer", "Lucas", "Holland", "Wong", "Banks", "Santos", "Curtis", "Pearson", "Delgado", "Valdez", "Pena", "Rios", "Douglas", "Sandoval", "Barrett", "Hopkins", "Keller", "Guerrero", "Stanley", "Bates", "Alvarado", "Beck", "Ortega", "Wade", "Estrada", "Contreras", "Barnett", "Caldwell", "Santiago", "Lambert", "Powers", "Chambers", "Nunez", "Craig", "Leonard", "Lowe", "Rhodes", "Byrd", "Gregory", "Shelton", "Frazier", "Becker", "Maldonado", "Fleming", "Vega", "Sutton", "Cohen", "Jennings", "Parks", "Mcdaniel", "Watts", "Barker", "Norris", "Vaughn", "Vazquez", "Holt", "Schwartz", "Steele", "Benson", "Neal", "Dominguez", "Horton", "Terry", "Wolfe", "Hale", "Lyons", "Graves", "Haynes", "Miles", "Park", "Warner", "Padilla", "Bush", "Thornton", "Mccarthy", "Mann", "Zimmerman", "Erickson", "Fletcher", "Mckinney", "Page", "Dawson", "Joseph", "Marquez", "Reeves", "Klein", "Espinoza", "Baldwin", "Moran", "Love", "Robbins", "Higgins", "Ball", "Cortez", "Le", "Griffith", "Bowen", "Sharp", "Cummings", "Ramsey", "Hardy", "Swanson", "Barber", "Acosta", "Luna", "Chandler", "Blair", "Daniel", "Cross", "Simon", "Dennis", "Oconnor", "Quinn", "Gross", "Navarro", "Moss", "Fitzgerald", "Doyle", "Mclaughlin", "Rojas", "Rodgers", "Stevenson", "Singh", "Yang", "Figueroa", "Harmon", "Newton", "Paul", "Manning", "Garner", "Mcgee", "Reese", "Francis", "Burgess", "Adkins", "Goodman", "Curry", "Brady", "Christensen", "Potter", "Walton", "Goodwin", "Mullins", "Molina", "Webster", "Fischer", "Campos", "Avila", "Sherman", "Todd", "Chang", "Blake", "Malone", "Wolf", "Hodges", "Juarez", "Gill", "Farmer", "Hines", "Gallagher", "Duran", "Hubbard", "Cannon", "Miranda", "Wang", "Saunders", "Tate", "Mack", "Hammond", "Carrillo", "Townsend", "Wise", "Ingram", "Barton", "Mejia", "Ayala", "Schroeder", "Hampton", "Rowe", "Parsons", "Frank", "Waters", "Strickland", "Osborne", "Maxwell", "Chan", "Deleon", "Norman", "Harrington", "Casey", "Patton", "Logan", "Bowers", "Mueller", "Glover", "Floyd", "Hartman", "Buchanan", "Cobb", "French", "Kramer", "Mccormick", "Clarke", "Tyler", "Gibbs", "Moody", "Conner", "Sparks", "Mcguire", "Leon", "Bauer", "Norton", "Pope", "Flynn", "Hogan", "Robles", "Salinas", "Yates", "Lindsey", "Lloyd", "Marsh", "Mcbride", "Owen", "Solis", "Pham", "Lang", "Pratt", "Lara", "Brock", "Ballard", "Trujillo", "Shaffer", "Drake", "Roman", "Aguirre", "Morton", "Stokes", "Lamb", "Pacheco", "Patrick", "Cochran", "Shepherd", "Cain", "Burnett", "Hess", "Li", "Cervantes", "Olsen", "Briggs", "Ochoa", "Cabrera", "Velasquez", "Montoya", "Roth", "Meyers", "Cardenas", "Fuentes", "Weiss", "Hoover", "Wilkins", "Nicholson", "Underwood", "Short", "Carson", "Morrow", "Colon", "Holloway", "Summers", "Bryan", "Petersen", "Mckenzie", "Serrano", "Wilcox", "Carey", "Clayton", "Poole", "Calderon", "Gallegos", "Greer", "Rivas", "Guerra", "Decker", "Collier", "Wall", "Whitaker", "Bass", "Flowers", "Davenport", "Conley", "Houston", "Huff", "Copeland", "Hood", "Monroe", "Massey", "Roberson", "Combs", "Franco", "Larsen", "Pittman", "Randall", "Skinner", "Wilkinson", "Kirby", "Cameron", "Bridges", "Anthony", "Richard", "Kirk", "Bruce", "Singleton", "Mathis", "Bradford", "Boone", "Abbott", "Charles", "Allison", "Sweeney", "Atkinson", "Horn", "Jefferson", "Rosales", "York", "Christian", "Phelps", "Farrell", "Castaneda", "Nash", "Dickerson", "Bond", "Wyatt", "Foley", "Chase", "Gates", "Vincent", "Mathews", "Hodge", "Garrison", "Trevino", "Villarreal", "Heath", "Dalton", "Valencia", "Callahan", "Hensley", "Atkins", "Huffman", "Roy", "Boyer", "Shields", "Lin", "Hancock", "Grimes", "Glenn", "Cline", "Delacruz", "Camacho", "Dillon", "Parrish", "Oneill", "Melton", "Booth", "Kane", "Berg", "Harrell", "Pitts", "Savage", "Wiggins", "Brennan", "Salas", "Marks", "Russo", "Sawyer", "Baxter", "Golden", "Hutchinson", "Liu", "Walter", "Mcdowell", "Wiley", "Rich", "Humphrey", "Johns", "Koch", "Suarez", "Hobbs", "Beard", "Gilmore", "Ibarra", "Keith", "Macias", "Khan", "Andrade", "Ware", "Stephenson", "Henson", "Wilkerson", "Dyer", "Mcclure", "Blackwell", "Mercado", "Tanner", "Eaton", "Clay", "Barron", "Beasley", "Oneal", "Preston", "Small", "Wu", "Zamora", "Macdonald", "Vance", "Snow", "Mcclain", "Stafford", "Orozco", "Barry", "English", "Shannon", "Kline", "Jacobson", "Woodard", "Huang", "Kemp", "Mosley", "Prince", "Merritt", "Hurst", "Villanueva", "Roach", "Nolan", "Lam", "Yoder", "Mccullough", "Lester", "Santana", "Valenzuela", "Winters", "Barrera", "Leach", "Orr", "Berger", "Mckee", "Strong", "Conway", "Stein", "Whitehead", "Bullock", "Escobar", "Knox", "Meadows", "Solomon", "Velez", "Odonnell", "Kerr", "Stout", "Blankenship", "Browning", "Kent", "Lozano", "Bartlett", "Pruitt", "Buck", "Barr", "Gaines", "Durham", "Gentry", "Mcintyre", "Sloan", "Melendez", "Rocha", "Herman", "Sexton", "Moon", "Hendricks", "Rangel", "Stark", "Lowery", "Hardin", "Hull", "Sellers", "Ellison", "Calhoun", "Gillespie", "Mora", "Knapp", "Mccall", "Morse", "Dorsey", "Weeks", "Nielsen", "Livingston", "Leblanc", "Mclean", "Bradshaw", "Glass", "Middleton", "Buckley", "Schaefer", "Frost", "Howe", "House", "Mcintosh", "Ho", "Pennington", "Reilly", "Hebert", "Mcfarland", "Hickman", "Noble", "Spears", "Conrad", "Arias", "Galvan", "Velazquez", "Huynh", "Frederick", "Randolph", "Cantu", "Fitzpatrick", "Mahoney", "Peck", "Villa", "Michael", "Donovan", "Mcconnell", "Walls", "Boyle", "Mayer", "Zuniga", "Giles", "Pineda", "Pace", "Hurley", "Mays", "Mcmillan", "Crosby", "Ayers", "Case", "Bentley", "Shepard", "Everett", "Pugh", "David", "Mcmahon", "Dunlap", "Bender", "Hahn", "Harding", "Acevedo", "Raymond", "Blackburn", "Duffy", "Landry", "Dougherty", "Bautista", "Shah", "Potts", "Arroyo", "Valentine", "Meza", "Gould", "Vaughan", "Fry", "Rush", "Avery", "Herring", "Dodson", "Clements", "Sampson", "Tapia", "Bean", "Lynn", "Crane", "Farley", "Cisneros", "Benton", "Ashley", "Mckay", "Finley", "Best", "Blevins", "Friedman", "Moses", "Sosa", "Blanchard", "Huber", "Frye", "Krueger", "Bernard", "Rosario", "Rubio", "Mullen", "Benjamin", "Haley", "Chung", "Moyer", "Choi", "Horne", "Yu", "Woodward", "Ali", "Nixon", "Hayden", "Rivers", "Estes", "Mccarty", "Richmond", "Stuart", "Maynard", "Brandt", "Oconnell", "Hanna", "Sanford", "Sheppard", "Church", "Burch", "Levy", "Rasmussen", "Coffey", "Ponce", "Faulkner", "Donaldson", "Schmitt", "Novak", "Costa", "Montes", "Booker", "Cordova", "Waller", "Arellano", "Maddox", "Mata", "Bonilla", "Stanton", "Compton", "Kaufman", "Dudley", "Mcpherson", "Beltran", "Dickson", "Mccann", "Villegas", "Proctor", "Hester", "Cantrell", "Daugherty", "Cherry", "Bray", "Davila", "Rowland", "Levine", "Madden", "Spence", "Good", "Irwin", "Werner", "Krause", "Petty", "Whitney", "Baird", "Hooper", "Pollard", "Zavala", "Jarvis", "Holden", "Haas", "Hendrix", "Mcgrath", "Bird", "Lucero", "Terrell", "Riggs", "Joyce", "Mercer", "Rollins", "Galloway", "Duke", "Odom", "Andersen", "Downs", "Hatfield", "Benitez", "Archer", "Huerta", "Travis", "Mcneil", "Hinton", "Zhang", "Hays", "Mayo", "Fritz", "Branch", "Mooney", "Ewing", "Ritter", "Esparza", "Frey", "Braun", "Gay", "Riddle", "Haney", "Kaiser", "Holder", "Chaney", "Mcknight", "Gamble", "Vang", "Cooley", "Carney", "Cowan", "Forbes", "Ferrell", "Davies", "Barajas", "Shea", "Osborn", "Bright", "Cuevas", "Bolton", "Murillo", "Lutz", "Duarte", "Kidd" };
    public List<Transform> houses;
    public List<Transform> buildings;
    public uint tasksPerPerson;
    public uint totalNumTasks = Config.tasksPerDay;
    public uint taksDuration = Config.taskDuration;
    public uint tasksCompleted = 0;
    public uint npcsFinished = 0;
    public GameObject PopulationList;
    public uint population;
    public uint initialNumInfected = Config.initInfectPop;
    //public int infectionRate = Config.initRate;
    public static uint numInfected;
    public List<GameObject> npcsToLoad;
    public static List<NPC> npcList = new List<NPC>();

    System.Random rnd = new System.Random();

    void Start() {
        Time.timeScale = 2f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
        System.Random rnd = new System.Random();
        totalNumTasks = tasksPerPerson * population;
        
        int housesLength = houses.Count;
        int buildingsLength = buildings.Count;
        int npcLength = npcsToLoad.Count;
        for (int i = 0; i < population; i++) {
            GameObject newNPCObject = Instantiate(npcsToLoad[rnd.Next(npcLength)], PopulationList.transform);
            NavMeshAgent navMeshAgent = newNPCObject.GetComponent<NavMeshAgent>();
            Transform house = houses[rnd.Next(housesLength)];
            Transform door = house.Find("Door").transform;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(door.position, out hit, 20f, NavMesh.AllAreas)) {
                navMeshAgent.Warp(hit.position);
            }
            else {
                Debug.Log("ERROR FINDING SAMPLE POSITION");
            }               

            NPC newNPC = newNPCObject.AddComponent<NPC>();
            List<Task> currentTasks = new List<Task>();

            for (int j = 0; j < tasksPerPerson; j++) {
                currentTasks.Add(new Task(buildings[rnd.Next(buildingsLength)].Find("Door").transform));
            }

            newNPC.loadTasks(currentTasks.ToArray());
            newNPC.house = house;
            newNPC.index = i;
            if (newNPC.gameObject.name.Contains("Female")) {
                newNPC.name = string.Format("{0} {1}", femaleFirstNames[rnd.Next(femaleFirstNames.Count)], lastNames[rnd.Next(lastNames.Count)]);
            }
            else if (newNPC.gameObject.name.Contains("Male")) {
                newNPC.name = string.Format("{0} {1}", maleFirstNames[rnd.Next(maleFirstNames.Count)], lastNames[rnd.Next(lastNames.Count)]);
            }
            // If initial number fo infected is greater than 0 set npc to infected
            if (i < initialNumInfected) {
                newNPC.isInfected = true;
                numInfected++;
                initialNumInfected--;
            }
            newNPC.completedDay.AddListener(() => {
                npcsFinished++;
                if(npcsFinished == population) {
                    dayFinished.Invoke();
                }
            });
            npcList.Add(newNPC);
        }
        // Call init function in CameraManager to eliminate script race condition
        NPCCamera.currentNPC = npcList[0];
    }

    public void reAssignTasks() {
        int buildingsLength = buildings.Count;
        foreach (NPC npc in npcList) {
            List<Task> currentTasks = new List<Task>();
            for (int j = 0; j < tasksPerPerson; j++) {
                currentTasks.Add(new Task(buildings[rnd.Next(buildingsLength)].Find("Door").transform));
            }
            npc.loadTasks(currentTasks.ToArray());
        }
    }
}