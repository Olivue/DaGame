using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGame
{
    internal class DaBosss
    {
        public string BossName;
        public int BossMaxHP;
        public int BossHP;
        public int BossAttack;
        public string BossImage;
        public string BossHint;
        public int CoolAttackNumber;
        static Random random = new Random();
        static string[] Names = { "Красновострая виверна", "Углокрылая морозница", "Ядовзорный василиск", "Хвостопоглощающий змий" };
        static string[] Hints = { "а", "н", "у", "с" };
        public static List<Action> CoolAttacks = new List<Action>() { SummonAttack, NegativeEffects, AutoHill, BossEvasion, QTE};
        public static List<DaBosss> Boss = new List<DaBosss>() {};
        public static void Bosses()
        {
            Boss.Add(new DaBosss() { BossName = Names[0], BossMaxHP = 50, BossHP = 50, BossAttack = 8, CoolAttackNumber = 0, BossHint = Hints[0], BossImage = Wyvern });
            Boss.Add(new DaBosss() { BossName = Names[1], BossMaxHP = 50, BossHP = 50, BossAttack = 8, CoolAttackNumber = 1, BossHint = Hints[1], BossImage = Hellebore });
            Boss.Add(new DaBosss() { BossName = Names[2], BossMaxHP = 50, BossHP = 50, BossAttack = 8, CoolAttackNumber = 2, BossHint = Hints[2], BossImage = Basilisk });
            Boss.Add(new DaBosss() { BossName = Names[3], BossMaxHP = 50, BossHP = 50, BossAttack = 8, CoolAttackNumber = 3, BossHint = Hints[3], BossImage = Serpent });
        }
        static void SummonAttack()
        {
            int rockAttack = random.Next(2, 9);
            Console.WriteLine("Враг задирает голову, и на всю округу раздается громогласный рев. Воздух дрожит. В рябящем воздухе появлсяются вполохи света. Когда они рассеиваюся, на их месте остается подкрепление.");
            Console.WriteLine("Звуковой волной тебя отбрасывает и ты ударяешься о землю, едва успевая сгруппироваться, чтобы не сломать конечности об острые камни.");
            Hero.HP -= rockAttack;
            Console.WriteLine("При ударе о землю ты получаешь " + rockAttack + " урона");
            int count = random.Next(1,4);
            for (int i = 0; i < count; i++)
			{
                enemy.ChooseEnemy(1);
			}
            Console.WriteLine("Теперь перед тобой:");
            foreach (enemy enemy in enemy.enemies)
            {
                Console.WriteLine(enemy.Name + " (" + enemy.HP + " здоровья)");
            }
        }

        static void NegativeEffects()
        {
            Console.WriteLine("Чудовище начинает звучно сопеть и подмахивать крыльями. Дым начинает выходить из раздувающихся ноздрей. Гонимый взмахами крыльев он быстро подбирается к твоим ногам и начинает обволакивать, поднимаясь выше и выше. Ты чувствуешь слабость");
            Console.WriteLine("Хватка слабеет, руки тяжелеют. Ты понимаешь, что не сможешь сражаться с прежней силой. Из носа капают капли крови. Этот дым отравлен!");
            Hero.DebaffCounter = 5;
            Hero.PoisonCounter = 3;
            Hero.HP -= Items.PoisonDamage;
            Console.WriteLine(Hero.Name + " получает урон ядом " + Items.PoisonDamage + " ед.");
        }

        static void AutoHill()
        {
            int HPExchange = random.Next(10, 19);
            Hero.HP -= HPExchange;
            foreach(enemy enemy in enemy.enemies)
            {
                if (enemy.BossChecker)
                {
                    enemy.HP += HPExchange;
                    if (enemy.MaxHP < enemy.HP) enemy.HP = enemy.MaxHP;
                }
            }
            Console.WriteLine("Чудовище резко начинает смотреть тебе прямо в глаза. Его пасть открывается. Ты слышишь тихое шипение. Ты хочешь напасть, но не можешь отвести взгляд.");
            Console.WriteLine("Шипение действует на тебя успокаивающее. Ты приходишь в себя и усилием воли стряхаешь с себя оцепенение, только когда чувствуешь как теряешь сознание, а жизнь будто утекает сквозь пальцы");
            Console.WriteLine("Монстр крадет " + HPExchange + " здоровья и восстанавливает свои силы");
        }

        static void BossEvasion()
        {
            Console.WriteLine("Чудовище пытается извернуться и избежать твоей атаки");
            Console.WriteLine("Оно уходит от удара в последний момент");
        }
        static void QTE()
        {

        }



        public static string Wyvern = @"

                '-.,;;:;,
                 _;\;|\;:;,
                ) __ ' \;::,
            .--'  e   ':;;;:,           ;,
           (^           ;;::;          ;;;,
   _        --_.--.___,',:;::;     ,,,;:;;;,
  < \        `;     |  ;:;;:;        ':;:;;;,,
<`-; \__     ,;    /    ';:;;:,       ';;;'
<`_   __',   ; ,  /    ::;;;:         //
   `)|  \ \   ` .'      ';;:;,       //
    `    \ `\  /        ;;:;;.      //__
          \  `/`         ;:;  ~._,=~`   `~=,
           \_|      (        ^     ^  ^ _^  \
             \    _,`      / ^ ^  ^   .' `.^ ;
    <`-.      '-;`       /`  ^   ^  /\    ) ^/
    <'- \__..-'` ___,,,-'._ ^  ^ _.'\^`'-' ^/
     `)_   ..-''`          `~~~~`    `~===~`
     <_.-`-._\
";
        public static string Hellebore = @"
                             _        _
                         _.-'/   _.:'`/
                      ,'`   ( ,:;.-'`(
                    .'      .:'`      \
                   /       //    _.-';)
                 _/      _//_.-;:-'``/
          //|    \      \  .-'`      \                                 ,
         || /_,-,_|      | ```--..__  \                  .-'```'-.     )\
    _.--'_  '-;_/_)_     |(````'---.;`/-,.-.  _         /  .---.  \  .'  \
   /6    ^`     ':_/     | `-._    .-'../__ )' ',.-. _ |  /     \  ;/_ _/
  (`-----`--'.    \_)    ;|``-.;-./        ```--;.__) ',-.      (| |  ||
 __)         {\   |_/\   \\    _.'                  ``-;_ )'-,_(`/ ; _.'/
  /         {=|   |)  \.-`\\  /                          `'-.;_:'  /_.'
            {=|    \_.'    )) '        /                          /
            {=|     ,                 |      ,                _.-'
             {=;     ```--.            \    '.       __,.---'`
              {=\          `\           '._   '._.-``
       _,.--``;{\ '-.._    /        __,..-'-._ '.
       (((/==)/ _`;.--'`` .'--```````  .--````    )
        ```  ' (((/====```            ((((/======'
                ```                    ```
";
        public static string Basilisk = @"

                                     /|   /|
                                    / /  / /
                                   | |  | |
                                   ; /  ; /
                     ___  __      / .\_/ ,(   ___ 
                    /  {.' {     / ;;;/ ;;;```_.-'
                 .--'-./ .-'    / ;;;/ ;;' .-'
              _.-` _  `;;\_,   / ;;;/ .' ,/
          ,-`` ;-= g>=- .; /  / ;;;/ ;',;;|
           \`__/_     ; ';|  | ;;;/.',;;;;'\___,
     _    ,=,-V-' __  ;;  _\ /.;/`.`.'` .,:---'
     ``==`  |_.-'`  7_;;  | | ;|  .',;;;;;/
                   /_,;'  /  \'\ `,;;;;;;|
                  {_,;'^ _\  /;;).,,,,,`'\
                 {_;;' ^|   /;/`.;;;;;;;-'`
                {_,;'^  _\ //`.,..`_';/
               (__;;  ^  \/`.;;;;;( ',|  
               (__,;,^ .'`.;;,.`';;      _.-/
               (__,';,/ ,;'.`;;;,._\  _.'  ( 
                (__,';|/|;';;.';/` .-' _   /
                 (__,-';|; ;;;. |._  `//)_/
                  (_/ '- \,'``\ | `'.// 
                .-' |'-' '-'';|/ ^   ';
               /'-' | '-' '-' ;`;;.^   `\
              /  '-' \  '-' '/\_, ';,  ^ \
              |'-' .-'\-' '-'|  \_,';,  ^ \
         _     \  /    '.'-' \  //\_,; ^  |
       , _v\    \ |      \ '-( |;/ \_ ;   |
       v_\ `---_-' \      ;  / |;|  <_; ^ |
       (.-')(`` `'-'      | /  | ;`=';'  ;
        v</               ||    \ `'`  ^/
                          ||     '-...-'
                          ||
                     __  / |_
                   v-=_;` __ `)
                   v-(_.-'  `v
                      v

            ";
        public static string Serpent = @"
                     /\         /\__
                   // \       (  0 )_____/\            __
                  // \ \     (vv          o|          /^v\
                //    \ \   (vvvv  ___-----^        /^^/\vv\
              //  /     \ \ |vvvvv/               /^^/    \v\
             //  /       (\\/vvvv/              /^^/       \v\
            //  /  /  \ (  /vvvv/              /^^/---(     \v\
           //  /  /    \( /vvvv/----(O        /^^/           \v\
          //  /  /  \  (/vvvv/               /^^/             \v|
        //  /  /    \( vvvv/                /^^/               ||
       //  /  /    (  vvvv/                 |^^|              //
      //  / /    (  |vvvv|                  /^^/            //
     //  / /   (    \vvvvv\          )-----/^^/           //
    // / / (          \vvvvv\            /^^^/          //
   /// /(               \vvvvv\        /^^^^/          //
  ///(              )-----\vvvvv\    /^^^^/-----(      \\
 //(                        \vvvvv\/^^^^/               \\
/(                            \vvvv^^^/                 //
                                \vv^/         /        //
                                             /<______//
                                            <<<------/
                                             \<
                                               \
";
        public static string Leviathan = @"
           .-----------------------'\               /`----------.            
          /.-----------------------( \             / (`---------.\           
         //                       //\ \           //\_\          \\          
        //                       //  `.\         //   \\          ).         
       //     /\     /\         //     \\       /(     \\        ( |         
      //     ( (  .--) )--.-'\ //______ )\  .--------.  \\        ||         
     //       \ \'  / /------{/_/-'/___}---/          \  \\       ||         
    //        /'' '''/  .-------/__>,          \     ,<\  )\      ||         
   ( )        >@) (@)' /\_/---<__.-'            `-.   //  \ \     ||         
    \\      .<``/ ;,,'')  ___.---'__.----.        (\  \\   \ \    |'         
     \\    {O__O}' )  /.--'_.-' ________,-\        \` ' )   \ \   |          
      \\   (/^^\) /  //_,-'----'    \-.---^----,--' >-  >    \ \  |          
       \\  ,-----/  //   ___LL.----._>-\           (   /\     \ \ |          
        \)'   (\'/)'/`. /.-_          ` >-----.   .-.  )/`.    \ )|          
         `    (_._(/   (/ /_X \--------/,        (|^|_.-.  `.  // |          
              `(T\'     \(<_)__)     .'        .-^(|) |^|    `((  |          
              ._)\\--.   \) ||     ,/  ,      ( X_ V, (|)      \\ |          
             (.--)\-'`\   ` ||   ,'|           `(_>-^-'V)       )\|          
              `\(('`\       |( ,'  |  ,              ` (        \ |          
                 `\         | )    |  @               ) \        )|          
                            |/     `-                / -(        )|          
                            `       `._\            '    `.     / |          
                       _____________(   `---------'___.---<    (  |          
                      /                           /_       \    \ |          
                    .'      _________.  `      .--'         )    \|          
                   (  _,   `              \  .'            /      '          
                    \ `       \__________.-^/      .   -,-'                  
                     \         |          _/  ___.   -' /                    
                      \        ,\        /   _/-------^T                     
                       \        \)    .-'  /(  (     ) |                     
                        \      ` \   (/-/._.'  (_   _) '                     
                         \      \ \  ' /'      (   ' )/                      
                          `.     \<           (`  , )'                       
                            ` .   ))        _(` ,  /                         
                               \_   >    _-' ,   .'                          
                               .'  /   .',  _.--'                            
                         .----' _ (   (/.--'      
                         (-'-._/(_ )  ('                                     
                                (-'

";
    }
}
