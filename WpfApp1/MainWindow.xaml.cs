﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        public MainWindow()
        {
            InitializeComponent();
            Room[] rooms = {
                //0
                new Room("\n\n\n\nВы Умерли...\n\n\n\n"),
                //1
                new Room("\nСвятозар Лучезарный, главный герой Древней Руси, внезапно теряет силы после сражения с главным Ящером болот Иноземных и погибает.\nНо тут боги Земли Матушки Руси взывают к нему, говорят, что рано пока ему к собратьям своим, ныне почившим, и возвращают героя на год назад\n-- О боги, что же произошло, где я?"),
                //2
                new Room("\n-- Это же Отчий дом! Но он сгорел много лун назад. Как я здесь оказался?"),
            //3
                new Room("\n-- Да и шрамов боевых меньше стало... Как же так? Что за проделки черта?"),
            //4
                new Room("\n-- Солнце будто ярче светит, хотя может мне кажется... \n-- Свяяяяят! Иди сюда! Ну же, скорее!\nСвятозар слышит голос, до боли знакомый. Брат... Родной... Но его же убил при мне Главный Ящер...\n  Святозар, еле сдерживая слезы, бежит к брату, обнимает его.\nОт такого внезапного действия Всеволод пошатнулся, но удержался на ногах. Приняв объятия, Всеволод  спрашивает:\n-- Братец, родной, что же ты плачешь? Нежели обидел тебя кто? \n-- Нет, брат, удивился я сильно, увидев тебя! Ты же умер от него..."),
            //5
                new Room("\n-- Успокойся же! Пойдем лучше в корчму меду выпьем! \n Но как же ящеры? Нам нужно срочно их изнечтожить, пока они нас всех не погубили!\nКакие еще ящеры, братец? Неужто приснился сон тебе кошмарный? Сходика лучше ты к Марье, она поможет тебе! \n "),
            //6
                new Room("\n-- Марья, подруга сердечная Я К те...\n -- Знаю, Святозарушка, зачем ко мне ты пришел... Ворожба сказала мне, что придет муж Руси Матушки ко мне, помочь ему должна я...\nИ знаю я как. Сходи, Святозар, за Тьмутаракань, в горы высокие. Там, глубоко в горах, прячутся твари иноземные, истреби их.\nНе забудь дружину собрать, иначе костей не соберешь! \n-- Спасибо за указ, бабушка, последую ему я.\n-- Удачи тебе, пусть Перун благоволит тебе!"),
            //7
                new Room("\nСвятозар заходит в корчму, видит, как десяток богатырей смотрят за битвой на кулаках между братом Всеволодом и каким-то знакомым витязем.\nСвятозар присоединяется к просмотру.\n --ВСЕ-ВО-ЛОД!\n--ВСЕ-ВО-ЛОД!\nВсеволод с размаху ударяет прямо в челюсть противнику, бой заканчивается...\n"),
            //8
                new Room("\n-- Ха-ха-ха-ха! Всем мёду от меня!\n--Неужто ты, Всеволод, молодняку решил класс показать?\n--Конечно! Ну а как их еще научить уму разуму, брат?\n--И то верно..."),
            //9
                new Room("\nСвятозар с Всеволодом выпивают глоток за глотком мед, будто бы соревнуясь. Кружка уже пуста."),
            //10
                new Room("\n-- Всеволод, у меня срочно дело есть. За Тьмутараканью, в горах высоких, живет нечисть иноземная, ящерами зовутся.\nСам Перун велел нам их погубить, Ворожея нас уже благословила. Осталось только дружину собрать.\n-- Это, здорово, хоть какое-то веселье! Есть у меня ребята здравые, человек 10 соберем, но нужно все же подумать, кого из них взять в силу главную...\n-- Вот гляди - есть тот парень, что со мною бился. Да, молодой он, сильный, храбрый, но неопытный. Да и в настоящем бою научится как биться нужно.\nСпроси его, но помни, слаб он пока для такого рода дел. \n-- Есть еще дядька наш Василевс. Хоть и стар он уже, но вояка бывалый. Опыт богатый, мудрый он, но все же слаб, да и слушаться нас не будет, все ему по своему сделать надо.\n-- Спасибо брат, подумаю я еще тогда..."),
            //11
                new Room("\nСвятозар выпивает еще кружку меду, и думает, кого бы взять\n-- Малец, хоть и не опытный, но послушный будет, силы ему точно не занимать, даже Всеволода чуть не победил, но, боюсь, Ящеры мудрее будут, да обманут его, а он и не заметит...\r\n\tСтарший же, скорее всего, помогать нам в бою не будет, но может помочь тактикой. Сломим ящеров, а они и не поймут!\n"),
            //12
                new Room("\n-- Друг мой! Призываю тебя я в бой с нечистью инородной! В горы, за Тьмутаракань пойдем! Пойдешь ли ты с дружиною нашей? Опыту наберешься, да и силу свою испробуешь.\nНо смотри, опасно это будет. Ящеры сила злобная, неизвестная, так и убить могут тебя в битве!\n-- Конечно пойду, старший! Как раз кулаки чесались!\n-- Тогда собирайся, выдвигаемся на рссвете, идти долго будем..."),
            //13
                new Room("\nВы пришли в Тьмутаракань...\n\nГород полностью разрушен, на улице нет признака жизни...\n\n-- Вот она какая, Тьмутаракань... Точнее была...\nВы прислушиваетесь, что-то бежит от вас за домом слева... Ящер!\n-- Братья! Изловить шпиона вражеского!\nВы и Ваша дружина бежите за мелким ящером, но он вбегает в закоулок, где вас ждут 3 средних Ящера.\n-- К бою, братцы!"),
            
                //бой

            //14
                new Room("\nВы поймали ящера разведчика..."),
            //15   
                new Room("\n-- Колись, супостат! Где же град ваш?  А ежели не скажешь, то замучаем тебя, но убивать не будем, заставим жить, терзая...\n--Смилуйся, богатырь... проведу я вас в град наш. Но послушай же, трудно нам приходится. Земля наша иссохла, урожая нет уже годами, народ наш мучается.\r\n\tЗемли для отроков наших больше нет. Только, захватывая, можем мы прожить чуть дольше.\n-- то ты мне тут рассказываешь, мелочь, лучше расскажи да покажи куда идти к главному вашему, с ним разговаривать буду!\n-- Тогда идем, витязь!"),
            //16
                new Room("\nВы пришли в поселение Ящеров..."),
            //17
                new Room("\nВокруг сидят семьи ящеров вокруг костров, разруха.\nВас отводят к главному ящеру, который сидел в крупном шатре, в окружении пяти ящеров-генералов"),
            //18 
                new Room("\n-- Дружинники! Рад приветствовать у себя! Зачем же вы проделали такой путь, храбрые воины? Убить ли меня вы хотите или беседу вести будете?\n-- Это будет зависить от того, что ты расскажешь нам, ежели опасность почуем - мигом меч у горла поставлю!\n-- Полно вам, ребята! Горе у нашего народа случилось, Топи наши родимые иссохли совсем, погибли товарищи наши, от голода. \nОт того и пришлось нам прийти в ваши земли. Простите нас и наши деяния!\n-- Старший! Не надо убивать их! Давайте лучше прогоним их, пусть земли врагов наших забирают, наши же останутся нам!\n-- Как же так, младший! Нам же потом аукнется это! Но может мы и сможем пользу извлечь из этого..."),
            //19
                new Room("\n-- Не могу я позволить грабить наши земли, ни сейчас, ни потом! Убить их всех!"),
            //20
                new Room("\n-- Слава Перуну! Победа Наша!"),
            //21
                new Room("\nПосле победы над Ящерами храбрая дружина вернулась домой и устроила пир на всю Русь Матушку. Выпивая литрами мёд Святозар вдруг задумался, что было бы, оставив он Ящеров в живых...\nМожет, все же не стоило устраивать резню...\nНо теперь это уже не узнать...\n\n\nКонец?\n\n\n"),
            //22
                new Room("\n-- Пусть это и непростой выбор, но душа моя болит! Живите, иноземцы, но с нашей земли уйдите! Вон, в земли половцев идите! Там земли вам хватит, а на наши не возвращайтесь!\n-- Благодарим тебя, Святозар! От всего племени!\n-- Идите же!"),
            //23
                new Room("\nПосле того, как вы решили пощадить Ящеров, вы вернулись домой, но чувствовали, что то решение было неправильным...\nВдруг они правда вернутся?\nВдруг они объединятся с половцами?\nНадо готовиться к худшему, но пока нужно дать душе отдохнуть...\n\n\nКонец?\n\n\n"),
            //24
                new Room("\n-- Не могу я младших в такую битву брать, не дорос он еще...\n\nВы подошли к Василевсу.\n\n-- Брат! Айда в горы, за Тьмутаракань! Земли наши надо защитить от иродов поганых!\n-- Вот еще! Да чтобы младшие мной коммандовали?! Да ни в жизнь!\n-- Друг мой, одумайся! Жизнь всей Руси на волоске!\n-- Пусть так, но не верю вам я, мелочь! Не пойду я с вами!\n-- Что же, придется нам идти в меньшенстве..."),

            };
        rooms[0].AddChoice("Начать заново", 1);
        rooms[1].AddChoice("Осмотреться", 2);
        rooms[1].AddChoice("Посмотреть на себя", 3);
        rooms[2].AddChoice("Выйти из хаты", 4);
        rooms[3].AddChoice("Выйти из хаты", 4);
        rooms[4].AddChoice("Пойти к Ворожеи", 5);
        rooms[5].AddChoice("Пойти в корчму", 6);
        rooms[6].AddChoice("Далее...", 7);
        rooms[7].AddChoice("Далее...", 8);
        rooms[8].AddChoice("Далее...", 9);
        rooms[9].AddChoice("Далее...", 10);
        rooms[10].AddChoice("Далее...", 11);
        rooms[11].AddChoice("Выбрать Малого", 12);

        rooms[11].AddChoice("Выбрать Старшего", 24);

        rooms[12].AddChoice("Выйти в поход...", 13);
        rooms[13].AddChoice("Хук в лицо", 0);
        rooms[13].AddChoice("Призыв молний Перуна", 0);
        rooms[13].AddChoice("Славянский зажим в тиски", 14);
        rooms[14].AddChoice("Далее...", 15);
        rooms[15].AddChoice("Пойти с ящером-разведчиком", 16);
        rooms[16].AddChoice("Далее...", 17);
        rooms[17].AddChoice("Далее...", 18);
        rooms[18].AddChoice("Пощадить", 22);
        rooms[18].AddChoice("Убить их!", 19);
        rooms[19].AddChoice("Окропить водой Байкальской!", 0);
        rooms[19].AddChoice("Славянский зажим в тиски", 0);
        rooms[19].AddChoice("Призыв молнии Перуна", 0);
        rooms[19].AddChoice("Глубокое проникновение копья", 20);
        rooms[20].AddChoice("Далее...", 21);
        rooms[22].AddChoice("Далее...", 23);
        rooms[24].AddChoice("Выйти в поход", 13)
        ;


            Player player = new Player("Игрок", 1);
            game = new Game(player, rooms);
        }

        void PlayGame(Game game)
        {
            Room currentRoom = game.Rooms[game.Player.CurrentRoom];
            Label.Content = currentRoom.Description;

            // Очищаем предыдущие кнопки
            buttonPanel.Children.Clear();

            // Создаем кнопки для каждого выбора в текущей комнате
            foreach (var choice in currentRoom.Choices)
            {
                Button choiceButton = new Button();
                choiceButton.Content = choice.Description;
                choiceButton.Tag = choice.NextRoom; // Индекс комнаты, связанной с выбором
                choiceButton.Click += ChoiceButton_Click; // Обработчик события нажатия кнопки
                buttonPanel.Children.Add(choiceButton);
            }

        }
        private void ChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            int nextRoomIndex = (int)((Button)sender).Tag; // Получаем индекс комнаты из Tag кнопки

            // Перемещаем игрока в следующую комнату
            game.Player.CurrentRoom = nextRoomIndex;

            // Продолжаем игру с обновленной комнатой
            PlayGame(game);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PlayGame(game);

            (sender as Button).Visibility = Visibility.Collapsed;
        }

        static void SaveGame(Game game)
        {
            try
            {
                using (FileStream fs = new FileStream("savegame.dat", FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, game);
                }

                Console.WriteLine("Игра сохранена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении игры: " + ex.Message);
            }
        }

        //функция загрузки игры
        static void LoadGame(out Game game)
        {
            game = null; // Инициализация, чтобы избежать ошибки компилятора

            try
            {
                using (FileStream fs = new FileStream("savegame.dat", FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    game = (Game)formatter.Deserialize(fs);
                }

                Console.WriteLine("Игра успешно загружена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке игры: " + ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SaveGame(game);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            (button as Button).Visibility = Visibility.Collapsed;
            // Загрузка игры
            Game loadedGame;
            LoadGame(out loadedGame);
            if (loadedGame != null)
            {
                // Продолжаем игру с загруженным состоянием
                PlayGame(loadedGame);
            }
        }
    }
}