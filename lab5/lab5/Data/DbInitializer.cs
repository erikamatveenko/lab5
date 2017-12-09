﻿using lab5.Models;
using lab5.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UchetContext db)
        {
            db.Database.EnsureCreated();

            int brandsNumber = 10000;
            int ownersNumber = 10000;
            int carsNumber = 200;

            InitializeOwners(db, ownersNumber);
            InitializeBrands(db, brandsNumber);
            InitializeCars(db, carsNumber, brandsNumber, ownersNumber);

        }

        private static void InitializeCars(UchetContext db, int carsNumber, int brandsNumber, int ownersNumber)
        {
            db.Database.EnsureCreated();

            //Проверка, занесены ли Cars
            if (db.Cars.Any())
            {
                return;   //База данных инициализирована
            }

            InitialStartPageCars(db);

            int brandID;
            int ownerID;
            string carRegistrationNumber;
            int carPhoto;
            string carNumberOfBody;
            string carNumberOfMotor;
            string carNumberOfPassport;
            DateTime carReleaseDate;
            DateTime carRegistrationDate;
            DateTime carLastCheckupDate;
            string carColor;
            string carDescription;


            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int CarID = 11; CarID <= carsNumber; CarID++)
            {
                carRegistrationNumber = MyRandom.RandomString(9);
                carNumberOfBody = MyRandom.RandomString(15);
                carNumberOfMotor = MyRandom.RandomString(15);
                carNumberOfPassport = MyRandom.RandomString(9);
                carColor = MyRandom.RandomString(7);
                carDescription = MyRandom.RandomString(10);

                carReleaseDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                carRegistrationDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                carLastCheckupDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));

                brandID = randObj.Next(1, brandsNumber - 1);
                ownerID = randObj.Next(1, ownersNumber - 1);
                carPhoto = randObj.Next(1, 500);




                db.Cars.Add(new Car
                {
                    BrandID = brandID,
                    OwnerID = ownerID,
                    CarRegistrationNumber = carRegistrationNumber,
                    CarPhoto = carPhoto,
                    CarNumberOfBody = carNumberOfBody,
                    CarNumberOfMotor = carNumberOfMotor,
                    CarNumberOfPassport = carNumberOfPassport,
                    CarReleaseDate = carReleaseDate,
                    CarRegistrationDate = carRegistrationDate,
                    CarLastCheckupDate = carLastCheckupDate,
                    CarColor = carColor,
                    CarDescription = carDescription,
                });



            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

        }
        private static void InitializeBrands(UchetContext db, int brandsNumber)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли Brands
            if (db.Brands.Any())
            {
                return;   // База данных инициализирована
            }

            InitialStartPageBrands(db);

            string brandName;
            string brandCompany;
            string brandCountry;
            DateTime brandStartDate;
            DateTime brandEndingDate;
            string brandCharacteristic;
            string brandCategory;
            string brandDescription;


            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int BrandID = 11; BrandID <= brandsNumber; BrandID++)
            {
                brandName = MyRandom.RandomString(7);
                brandCompany = MyRandom.RandomString(10);
                brandCountry = MyRandom.RandomString(10);
                brandStartDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                brandEndingDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                brandCharacteristic = MyRandom.RandomString(15);
                brandCategory = MyRandom.RandomString(7);
                brandDescription = MyRandom.RandomString(10);


                db.Brands.Add(new Brand
                {
                    BrandName = brandName,
                    BrandCompany = brandCompany,
                    BrandCountry = brandCountry,
                    BrandStartDate = brandStartDate,
                    BrandEndingDate = brandEndingDate,
                    BrandCharacteristic = brandCharacteristic,
                    BrandCategory = brandCategory,
                    BrandDescription = brandDescription
                });
            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

        }
        private static void InitializeOwners(UchetContext db, int ownersNumber)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли Owners
            if (db.Owners.Any())
            {
                return;   // База данных инициализирована
            }



            InitialStartPageOwner(db);

            string ownerName;
            DateTime ownerBirthDate;
            string ownerAddress;
            string ownerPassport;
            int ownerNumberOfDriverLicense;
            DateTime ownerLicenseDeliveryDate;
            DateTime ownerLicenseValidityDate;
            string ownerCategory;
            string ownerMoreInformation;

            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int OwnerID = 11; OwnerID <= ownersNumber; OwnerID++)
            {
                ownerName = MyRandom.RandomString(20);
                ownerAddress = MyRandom.RandomString(20);
                ownerPassport = MyRandom.RandomString(10);
                ownerBirthDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerLicenseDeliveryDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerLicenseValidityDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerCategory = MyRandom.RandomString(15);
                ownerNumberOfDriverLicense = randObj.Next(1, 3000);
                ownerMoreInformation = MyRandom.RandomString(10);



                db.Owners.Add(new Owner
                {
                    OwnerName = ownerName,
                    OwnerBirthDate = ownerBirthDate,
                    OwnerAddress = ownerAddress,
                    OwnerPassport = ownerPassport,
                    OwnerNumberOfDriverLicense = ownerNumberOfDriverLicense,
                    OwnerLicenseDeliveryDate = ownerLicenseDeliveryDate,
                    OwnerLicenseValidityDate = ownerLicenseValidityDate,
                    OwnerCategory = ownerCategory,
                    OwnerMoreInformation = ownerMoreInformation
                });
            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

        }

        private static void InitialStartPageCars(UchetContext db)
        {
            db.Cars.Add(new Car
            {
                BrandID = 2,
                OwnerID = 1,
                CarRegistrationNumber = "3194 KK-4",
                CarPhoto = 1,
                CarNumberOfBody = "XTA217230C0222222",
                CarNumberOfMotor = "F4B - 1.4л/55кВт",
                CarNumberOfPassport = "EGFV4151V",
                CarReleaseDate = new DateTime(2005,12,08),
                CarRegistrationDate = new DateTime(2008,06,09),
                CarLastCheckupDate = new DateTime(2015,09,08),
                CarColor = "Голубой",
                CarDescription = "Спортивный седан",
            });

            db.Cars.Add(new Car
            {
                BrandID = 5,
                OwnerID = 4,
                CarRegistrationNumber = "3826 AT-2",
                CarPhoto = 2,
                CarNumberOfBody = "LJ78-0009746",
                CarNumberOfMotor = "F6F - 1.4л/55кВт",
                CarNumberOfPassport = "RG22X9GRE",
                CarReleaseDate = new DateTime(2008, 11, 08),
                CarRegistrationDate = new DateTime(2012, 08, 02),
                CarLastCheckupDate = new DateTime(2017, 10, 11),
                CarColor = "Синий",
                CarDescription = "Седан",
            });

            db.Cars.Add(new Car
            {
                BrandID = 8,
                OwnerID = 1,
                CarRegistrationNumber = "8864 EH-3",
                CarPhoto = 3,
                CarNumberOfBody = "AE115-3016544",
                CarNumberOfMotor = "FUH - 1.4л/55кВт",
                CarNumberOfPassport = "ERGV415GV",
                CarReleaseDate = new DateTime(2009, 12, 18),
                CarRegistrationDate = new DateTime(2010, 08, 05),
                CarLastCheckupDate = new DateTime(2014, 10, 25),
                CarColor = "Серый",
                CarDescription = "Внедорожник ",
            });

            db.Cars.Add(new Car
            {
                BrandID = 9,
                OwnerID = 5,
                CarRegistrationNumber = "3181 EE-6",
                CarPhoto = 4,
                CarNumberOfBody = "EXZ10-0020027",
                CarNumberOfMotor = "J4B - 1.3л/44кВт",
                CarNumberOfPassport = "EDBED4DED",
                CarReleaseDate = new DateTime(2015, 08, 28),
                CarRegistrationDate = new DateTime(2015, 10, 08),
                CarLastCheckupDate = new DateTime(2016, 07, 27),
                CarColor = "Черный",
                CarDescription = "Универсал",
            });

            db.Cars.Add(new Car
            {
                BrandID = 1,
                OwnerID = 6,
                CarRegistrationNumber = "4181 EP-6",
                CarPhoto = 5,
                CarNumberOfBody = "WF0FXX3BBF5115",
                CarNumberOfMotor = "J6A - 1.3л/44кВт",
                CarNumberOfPassport = "5520ERG9Z",
                CarReleaseDate = new DateTime(2009, 02,06),
                CarRegistrationDate = new DateTime(2016, 01, 16),
                CarLastCheckupDate = new DateTime(2017, 09, 14),
                CarColor = "Черный",
                CarDescription = "Кроссовер",
            });

            db.Cars.Add(new Car
            {
                BrandID = 3,
                OwnerID = 9,
                CarRegistrationNumber = "4000 IX-5",
                CarPhoto = 6,
                CarNumberOfBody = "WBACG82080RL790079",
                CarNumberOfMotor = "JBD - 1.3л/44кВт",
                CarNumberOfPassport = "EGVE5241V",
                CarReleaseDate = new DateTime(2008, 07, 20),
                CarRegistrationDate = new DateTime(2009, 05, 03),
                CarLastCheckupDate = new DateTime(2013, 12, 13),
                CarColor = "Белый",
                CarDescription = "Седан",
            });

            db.Cars.Add(new Car
            {
                BrandID = 6,
                OwnerID = 10,
                CarRegistrationNumber = "4442 BX-3",
                CarPhoto = 7,
                CarNumberOfBody = "1BEJ56H9WN28995",
                CarNumberOfMotor = "NET— 2,0 НС ОНС 77 кВт",
                CarNumberOfPassport = "ERGVRE5G9",
                CarReleaseDate = new DateTime(2011, 12, 12),
                CarRegistrationDate = new DateTime(2015, 08, 23),
                CarLastCheckupDate = new DateTime(2017, 10, 13),
                CarColor = "Синий",
                CarDescription = "Седан",
            });

            db.Cars.Add(new Car
            {
                BrandID = 4,
                OwnerID = 7,
                CarRegistrationNumber = "1990 KO-7",
                CarPhoto = 8,
                CarNumberOfBody = "NHW203549504",
                CarNumberOfMotor = "LCS — 1,6 НС ОНС 55 кВт",
                CarNumberOfPassport = "ERGVSRE96",
                CarReleaseDate = new DateTime(2016, 05, 01),
                CarRegistrationDate = new DateTime(2017, 09, 15),
                CarLastCheckupDate = new DateTime(2017, 09, 20),
                CarColor = "Черный",
                CarDescription = "Кроссовер",
            });

            db.Cars.Add(new Car
            {
                BrandID = 7,
                OwnerID = 3,
                CarRegistrationNumber = "0813 BT-3",
                CarPhoto = 9,
                CarNumberOfBody = "CF513007941",
                CarNumberOfMotor = "LCT— 1,6 НС ОНС 55 кВт",
                CarNumberOfPassport = "REGV85518",
                CarReleaseDate = new DateTime(2010, 10, 10),
                CarRegistrationDate = new DateTime(2012, 02, 01),
                CarLastCheckupDate = new DateTime(2015, 07, 28),
                CarColor = "Серый",
                CarDescription = "Кабриолет",
            });

            db.Cars.Add(new Car
            {
                BrandID = 4,
                OwnerID = 6,
                CarRegistrationNumber = "0996 AX-2",
                CarPhoto = 10,
                CarNumberOfBody = "15BA-01041463",
                CarNumberOfMotor = "JCT— 1,3 НС ОНС 44 кВт",
                CarNumberOfPassport = "RFV541R24",
                CarReleaseDate = new DateTime(2005, 09, 21),
                CarRegistrationDate = new DateTime(2009, 05, 14),
                CarLastCheckupDate = new DateTime(2010, 10, 30),
                CarColor = "Красный",
                CarDescription = "Кроссовер",
            });


            db.SaveChanges();
        }

        private static void InitialStartPageBrands(UchetContext db)
        {
            db.Brands.Add(new Brand
            {
                BrandName = "Audi SQ7",
                BrandCompany = "Audi",
                BrandCountry = "Germany",
                BrandStartDate = new DateTime(2016, 10, 15),
                BrandEndingDate = new DateTime(2017, 05, 05),
                BrandCharacteristic = "Длина 5059 мм, ширина 1968 мм, высота 1741 мм, колесная база 2996 мм, 5 мест",
                BrandCategory = "3",
                BrandDescription = "Элегантный и стремительный дизайн, современная фальшрадиаторная решетка, передняя панель из качественных материалов с использованием карбоновых вставок"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "BMW M5 (E60)",
                BrandCompany = "BMW",
                BrandCountry = "Germany",
                BrandStartDate = new DateTime(2005, 04, 02),
                BrandEndingDate = new DateTime(2008, 11, 30),
                BrandCharacteristic = "Длина 4855 мм, ширина 1846 мм, высота 1469 мм, колесная база 2889 мм, объем топливного бака 70 л, 5 мест",
                BrandCategory = "2",
                BrandDescription = "Кожаные дверные панели, кожаная центральная консоль, ковры по всему салону, кондиционер, электрические стеклоподъёмники, электрический люк, электрические сиденья"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Mercedes-Benz S500",
                BrandCompany = "Mercedes-Benz",
                BrandCountry = "Germany",
                BrandStartDate = new DateTime(2015, 11, 04),
                BrandEndingDate = new DateTime(2017, 12, 14),
                BrandCharacteristic = "Длина 5027 мм, ширина 1899 мм, высота 1417 мм, колесная база 2945 мм, объем топливного бака 80 л, 4 места",
                BrandCategory = "3",
                BrandDescription = "Удобная эргономика, комфортабельные, вентилируемые сиденья с многоконтурной спинкой"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Ford EcoSport 1.6",
                BrandCompany = "Ford",
                BrandCountry = "USA",
                BrandStartDate = new DateTime(2014, 08, 20),
                BrandEndingDate = new DateTime(2015, 08, 04),
                BrandCharacteristic = "Длина 4273 мм, ширина 1765 мм, высота 1662 мм, колесная база 2519 мм, объем топливного бака 52 л, 5 мест",
                BrandCategory = "3",
                BrandDescription = "Компактный городской внедорожник, высокий клиренс и полный привод, легкосплавные диски, передняя и задняя серебристые защитные накладки и внешнее запасное колесо"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Toyota Corolla 1.33",
                BrandCompany = "Toyota",
                BrandCountry = "Japan",
                BrandStartDate = new DateTime(2016, 01, 09),
                BrandEndingDate = new DateTime(2017, 10, 22),
                BrandCharacteristic = "Длина 4620 мм, ширина 1775 мм, высота 1465 мм, колесная база 2700 мм, объем топливного бака 8550 л, 5 мест",
                BrandCategory = "2",
                BrandDescription = "Просторный салон, отделанный кожей"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Hyundai Avante 1.6",
                BrandCompany = "Hyundai",
                BrandCountry = "South Korea",
                BrandStartDate = new DateTime(2013, 06, 01),
                BrandEndingDate = new DateTime(2014, 03, 18),
                BrandCharacteristic = "Длина 4550 мм, ширина 1775 мм, высота 1435 мм, колесная база 2700 мм, объем топливного бака 60 л, 5 мест",
                BrandCategory = "2",
                BrandDescription = "Интегрированные дневные ходовые огни, увеличенная длина автомобиля, новый дизельный мотор"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Renault Wind 1.2",
                BrandCompany = "Renault",
                BrandCountry = "Slovenia",
                BrandStartDate = new DateTime(2010, 10, 24),
                BrandEndingDate = new DateTime(2012, 07, 07),
                BrandCharacteristic = "Длина 3828 мм, ширина 1698 мм, высота 1415 мм, колесная база 2368 мм, объем топливного бака 40 л, 2 места",
                BrandCategory = "2",
                BrandDescription = "Уникальный яркий дизайн, компактные размеры, легкое управление и динамичный двигатель, установлены спортивные сидения, алюминиевые педали и спортивное рулевое колесо"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Mazda CX-9 3.7 4WD",
                BrandCompany = "Mazda",
                BrandCountry = "Japan",
                BrandStartDate = new DateTime(2012, 12, 13),
                BrandEndingDate = new DateTime(2013, 08, 02),
                BrandCharacteristic = "Длина 5096 мм, ширина 1936 мм, высота 1728 мм, колесная база 2875 мм, объем топливного бака 76 л, 7 мест",
                BrandCategory = "3",
                BrandDescription = ""
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Honda Crosstour 2.4",
                BrandCompany = "Honda",
                BrandCountry = "Japan",
                BrandStartDate = new DateTime(2012, 11, 17),
                BrandEndingDate = new DateTime(2015, 06, 10),
                BrandCharacteristic = "Длина 4994 мм, ширина 1897 мм, высота 1562 мм, колесная база 2797 мм, объем топливного бака 70 л, 5 мест",
                BrandCategory = "3",
                BrandDescription = "Пятидверный кузов типа хэтчбек с оригинальным дизайном, пятиместный салон, увеличенный дорожный просвет"
            });

            db.Brands.Add(new Brand
            {
                BrandName = "Subaru Impreza WRX 2.0",
                BrandCompany = "Subaru",
                BrandCountry = "Japan",
                BrandStartDate = new DateTime(2014, 04, 01),
                BrandEndingDate = new DateTime(2015, 03, 18),
                BrandCharacteristic = "Длина 4595 мм, ширина 1795 мм, высота 1475 мм, колесная база 2650 мм, объем топливного бака 60 л, 5 мест",
                BrandCategory = "2",
                BrandDescription = "Агрессивный передний бампер, расширенные  пороги и крылья, диффузор"
            });


            db.SaveChanges();
        }

        private static void InitialStartPageOwner(UchetContext db)
        {
            db.Owners.Add(new Owner
            {
                OwnerName = "Исаева Екатерина Евгеньевна",
                OwnerBirthDate = new DateTime(1998,02,21),
                OwnerAddress = "Беларусь, г. Гомель, ул. Ленина, д. 2",
                OwnerPassport = "НВ5122705",
                OwnerNumberOfDriverLicense = 854897,
                OwnerLicenseDeliveryDate = new DateTime(2017,05,06),
                OwnerLicenseValidityDate = new DateTime(2022,05,06),
                OwnerCategory = "A",
                OwnerMoreInformation = "Место работы: \"Беларусбанк\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Гордеев Евгений Михайлович",
                OwnerBirthDate = new DateTime(1975, 12, 25),
                OwnerAddress = "Беларусь, г. Гомель, ул. Свиридова, д. 30, кв. 52",
                OwnerPassport = "НВ4589625",
                OwnerNumberOfDriverLicense = 18286,
                OwnerLicenseDeliveryDate = new DateTime(1996, 08, 14),
                OwnerLicenseValidityDate = new DateTime(2018, 08, 14),
                OwnerCategory = "A",
                OwnerMoreInformation = "Место работы: \"Школа №3\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Ситников Александр Дмитриевич",
                OwnerBirthDate = new DateTime(1988, 01, 08),
                OwnerAddress = "Беларусь, г. Гомель, ул. Привокзальная, д. 45, кв. 12",
                OwnerPassport = "НВ4586225",
                OwnerNumberOfDriverLicense = 54168,
                OwnerLicenseDeliveryDate = new DateTime(2008, 04, 15),
                OwnerLicenseValidityDate = new DateTime(2019, 04, 15),
                OwnerCategory = "B",
                OwnerMoreInformation = "Место работы: \"Станкогомель\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Шестакова Анастасия Андреевна",
                OwnerBirthDate = new DateTime(1958, 03, 19),
                OwnerAddress = "Беларусь, г. Гомель, ул. Ленина, д. 8, кв. 96",
                OwnerPassport = "НВ3656985",
                OwnerNumberOfDriverLicense = 2310574,
                OwnerLicenseDeliveryDate = new DateTime(2009, 12, 15),
                OwnerLicenseValidityDate = new DateTime(2025, 12, 15),
                OwnerCategory = "A",
                OwnerMoreInformation = "Место работы: \"ТЭЦ-1\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Симонов Андрей Вячеславович",
                OwnerBirthDate = new DateTime(1966, 07, 07),
                OwnerAddress = "Беларусь, г. Гомель, ул. Октябрьская, д. 25, кв. 48",
                OwnerPassport = "НВ1241525",
                OwnerNumberOfDriverLicense = 54156156,
                OwnerLicenseDeliveryDate = new DateTime(2012, 07, 23),
                OwnerLicenseValidityDate = new DateTime(2022, 07, 23),
                OwnerCategory = "C",
                OwnerMoreInformation = "Место работы: \"Химзавод\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Фёдорова Лидия Викторовна",
                OwnerBirthDate = new DateTime(1985, 11, 06),
                OwnerAddress = "Беларусь, г. Гомель, ул. Воровского, д. 36, кв. 4",
                OwnerPassport = "НВ7885122",
                OwnerNumberOfDriverLicense = 1502688,
                OwnerLicenseDeliveryDate = new DateTime(2011, 12, 07),
                OwnerLicenseValidityDate = new DateTime(2018, 12, 07),
                OwnerCategory = "B",
                OwnerMoreInformation = "Место работы: \"Автобусный парк №6\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Гришина Надежда Анатольевна",
                OwnerBirthDate = new DateTime(1981, 05, 01),
                OwnerAddress = "Беларусь, г. Гомель, ул. Гомельская, д. 19",
                OwnerPassport = "НВ2236998",
                OwnerNumberOfDriverLicense = 548952,
                OwnerLicenseDeliveryDate = new DateTime(2001, 09, 02),
                OwnerLicenseValidityDate = new DateTime(2023, 09, 02),
                OwnerCategory = "A",
                OwnerMoreInformation = "Место работы: \"ЗЛиН\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Пономарёв Роман Святославович",
                OwnerBirthDate = new DateTime(1992, 07, 16),
                OwnerAddress = "Беларусь, г. Гомель, ул. Карповича, д. 7, кв. 64",
                OwnerPassport = "НВ1025845",
                OwnerNumberOfDriverLicense = 203588,
                OwnerLicenseDeliveryDate = new DateTime(2010, 10, 16),
                OwnerLicenseValidityDate = new DateTime(2020, 10, 16),
                OwnerCategory = "A, B",
                OwnerMoreInformation = "Место работы: \"Гомсельмаш\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Крылов Алексей Михаилович",
                OwnerBirthDate = new DateTime(1979, 09, 10),
                OwnerAddress = "Беларусь, г. Гомель, ул. Белорусская, д. 5",
                OwnerPassport = "НВ59669854",
                OwnerNumberOfDriverLicense = 867458,
                OwnerLicenseDeliveryDate = new DateTime(2003, 11, 25),
                OwnerLicenseValidityDate = new DateTime(2019, 11, 25),
                OwnerCategory = "A",
                OwnerMoreInformation = "Место работы: \"Гомельторгмаш\" "
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Устинов Валерий Глебович",
                OwnerBirthDate = new DateTime(1996, 05, 12),
                OwnerAddress = "Беларусь, г. Гомель, ул. Мазурова, д. 45, кв. 3",
                OwnerPassport = "НВ2203655",
                OwnerNumberOfDriverLicense = 385418,
                OwnerLicenseDeliveryDate = new DateTime(2016, 07, 08),
                OwnerLicenseValidityDate = new DateTime(2026, 07, 08),
                OwnerCategory = "A, B",
                OwnerMoreInformation = "Место работы: \"Завод измерительных приборов\" "
            });

            db.SaveChanges();
        }
    }

}
