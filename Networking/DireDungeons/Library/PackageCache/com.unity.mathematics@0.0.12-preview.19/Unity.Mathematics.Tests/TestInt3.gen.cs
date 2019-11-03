// GENERATED CODE
using NUnit.Framework;
using static Unity.Mathematics.math;
namespace Unity.Mathematics.Tests
{
    [TestFixture]
    public class TestInt3
    {
        [Test]
        public void int3_constructor()
        {
            int3 a = new int3(1, 2, 3);
            Assert.AreEqual(a.x, 1);
            Assert.AreEqual(a.y, 2);
            Assert.AreEqual(a.z, 3);
        }

        [Test]
        public void int3_scalar_constructor()
        {
            int3 a = new int3(17);
            Assert.AreEqual(a.x, 17);
            Assert.AreEqual(a.y, 17);
            Assert.AreEqual(a.z, 17);
        }

        [Test]
        public void int3_static_constructor()
        {
            int3 a = int3(1, 2, 3);
            Assert.AreEqual(a.x, 1);
            Assert.AreEqual(a.y, 2);
            Assert.AreEqual(a.z, 3);
        }

        [Test]
        public void int3_static_scalar_constructor()
        {
            int3 a = int3(17);
            Assert.AreEqual(a.x, 17);
            Assert.AreEqual(a.y, 17);
            Assert.AreEqual(a.z, 17);
        }

        [Test]
        public void int3_operator_equal_wide_wide()
        {
            int3 a0 = int3(2105871082, 35218899, 1550755093);
            int3 b0 = int3(1477587886, 579629692, 540974792);
            bool3 r0 = bool3(false, false, false);
            TestUtils.AreEqual(a0 == b0, r0);

            int3 a1 = int3(764676020, 606743782, 1208156098);
            int3 b1 = int3(208405066, 2063397938, 1060167409);
            bool3 r1 = bool3(false, false, false);
            TestUtils.AreEqual(a1 == b1, r1);

            int3 a2 = int3(1023640014, 1038468316, 1416064367);
            int3 b2 = int3(362592601, 2097545362, 277670088);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 == b2, r2);

            int3 a3 = int3(727143393, 2061243891, 184669837);
            int3 b3 = int3(426944490, 901076223, 857900673);
            bool3 r3 = bool3(false, false, false);
            TestUtils.AreEqual(a3 == b3, r3);
        }

        [Test]
        public void int3_operator_equal_wide_scalar()
        {
            int3 a0 = int3(437822262, 2020661134, 541786900);
            int b0 = (1332833578);
            bool3 r0 = bool3(false, false, false);
            TestUtils.AreEqual(a0 == b0, r0);

            int3 a1 = int3(853113810, 179951405, 1409026299);
            int b1 = (23716499);
            bool3 r1 = bool3(false, false, false);
            TestUtils.AreEqual(a1 == b1, r1);

            int3 a2 = int3(948838849, 691955848, 1926262965);
            int b2 = (953202998);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 == b2, r2);

            int3 a3 = int3(1851546137, 2028784869, 1049962241);
            int b3 = (712957637);
            bool3 r3 = bool3(false, false, false);
            TestUtils.AreEqual(a3 == b3, r3);
        }

        [Test]
        public void int3_operator_equal_scalar_wide()
        {
            int a0 = (542329200);
            int3 b0 = int3(1115584594, 684107773, 1928988941);
            bool3 r0 = bool3(false, false, false);
            TestUtils.AreEqual(a0 == b0, r0);

            int a1 = (890709324);
            int3 b1 = int3(641152437, 1410341302, 497505660);
            bool3 r1 = bool3(false, false, false);
            TestUtils.AreEqual(a1 == b1, r1);

            int a2 = (1068223109);
            int3 b2 = int3(2014009435, 213835595, 1592428361);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 == b2, r2);

            int a3 = (1819361470);
            int3 b3 = int3(448650623, 1942175642, 64377057);
            bool3 r3 = bool3(false, false, false);
            TestUtils.AreEqual(a3 == b3, r3);
        }

        [Test]
        public void int3_operator_not_equal_wide_wide()
        {
            int3 a0 = int3(1977284100, 1293292704, 1547283851);
            int3 b0 = int3(1514195556, 957972049, 507667364);
            bool3 r0 = bool3(true, true, true);
            TestUtils.AreEqual(a0 != b0, r0);

            int3 a1 = int3(422428953, 195833190, 1711544892);
            int3 b1 = int3(581861672, 1128094576, 940096636);
            bool3 r1 = bool3(true, true, true);
            TestUtils.AreEqual(a1 != b1, r1);

            int3 a2 = int3(5606053, 737069074, 647386678);
            int3 b2 = int3(57559040, 181752616, 962017320);
            bool3 r2 = bool3(true, true, true);
            TestUtils.AreEqual(a2 != b2, r2);

            int3 a3 = int3(13079405, 1413841590, 1076166545);
            int3 b3 = int3(1762015406, 1107218953, 2042026522);
            bool3 r3 = bool3(true, true, true);
            TestUtils.AreEqual(a3 != b3, r3);
        }

        [Test]
        public void int3_operator_not_equal_wide_scalar()
        {
            int3 a0 = int3(1038269360, 1427812625, 103361237);
            int b0 = (768873026);
            bool3 r0 = bool3(true, true, true);
            TestUtils.AreEqual(a0 != b0, r0);

            int3 a1 = int3(1347017023, 150442802, 660334527);
            int b1 = (1523584313);
            bool3 r1 = bool3(true, true, true);
            TestUtils.AreEqual(a1 != b1, r1);

            int3 a2 = int3(719113717, 484398043, 506946952);
            int b2 = (262959423);
            bool3 r2 = bool3(true, true, true);
            TestUtils.AreEqual(a2 != b2, r2);

            int3 a3 = int3(226568494, 1702162286, 923269270);
            int b3 = (507918242);
            bool3 r3 = bool3(true, true, true);
            TestUtils.AreEqual(a3 != b3, r3);
        }

        [Test]
        public void int3_operator_not_equal_scalar_wide()
        {
            int a0 = (1652127596);
            int3 b0 = int3(953791238, 271722683, 1278885987);
            bool3 r0 = bool3(true, true, true);
            TestUtils.AreEqual(a0 != b0, r0);

            int a1 = (735128017);
            int3 b1 = int3(112416504, 25967222, 1761444475);
            bool3 r1 = bool3(true, true, true);
            TestUtils.AreEqual(a1 != b1, r1);

            int a2 = (1844594536);
            int3 b2 = int3(1199122922, 634219279, 942501101);
            bool3 r2 = bool3(true, true, true);
            TestUtils.AreEqual(a2 != b2, r2);

            int a3 = (67161343);
            int3 b3 = int3(969944293, 833229499, 1304301133);
            bool3 r3 = bool3(true, true, true);
            TestUtils.AreEqual(a3 != b3, r3);
        }

        [Test]
        public void int3_operator_less_wide_wide()
        {
            int3 a0 = int3(1486550609, 1779244308, 1602148045);
            int3 b0 = int3(97842578, 536551311, 413528975);
            bool3 r0 = bool3(false, false, false);
            TestUtils.AreEqual(a0 < b0, r0);

            int3 a1 = int3(1614085440, 1975613414, 942838342);
            int3 b1 = int3(1838293684, 1283898480, 1456599961);
            bool3 r1 = bool3(true, false, true);
            TestUtils.AreEqual(a1 < b1, r1);

            int3 a2 = int3(1092279031, 373677431, 1419098312);
            int3 b2 = int3(1080278602, 529676676, 156584048);
            bool3 r2 = bool3(false, true, false);
            TestUtils.AreEqual(a2 < b2, r2);

            int3 a3 = int3(337757077, 1081797900, 1336745069);
            int3 b3 = int3(117348799, 246927124, 1916615924);
            bool3 r3 = bool3(false, false, true);
            TestUtils.AreEqual(a3 < b3, r3);
        }

        [Test]
        public void int3_operator_less_wide_scalar()
        {
            int3 a0 = int3(796797557, 670113454, 933579492);
            int b0 = (746564682);
            bool3 r0 = bool3(false, true, false);
            TestUtils.AreEqual(a0 < b0, r0);

            int3 a1 = int3(278884514, 1117630673, 741886928);
            int b1 = (318174822);
            bool3 r1 = bool3(true, false, false);
            TestUtils.AreEqual(a1 < b1, r1);

            int3 a2 = int3(1990922600, 1546212312, 1718582899);
            int b2 = (1030849597);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 < b2, r2);

            int3 a3 = int3(1648393417, 1909506562, 1294006045);
            int b3 = (1857132231);
            bool3 r3 = bool3(true, false, true);
            TestUtils.AreEqual(a3 < b3, r3);
        }

        [Test]
        public void int3_operator_less_scalar_wide()
        {
            int a0 = (186400299);
            int3 b0 = int3(1881344229, 813834467, 1254886626);
            bool3 r0 = bool3(true, true, true);
            TestUtils.AreEqual(a0 < b0, r0);

            int a1 = (1353590345);
            int3 b1 = int3(1412343685, 1555571443, 1540508298);
            bool3 r1 = bool3(true, true, true);
            TestUtils.AreEqual(a1 < b1, r1);

            int a2 = (1735458634);
            int3 b2 = int3(135888070, 1643818742, 248291654);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 < b2, r2);

            int a3 = (1739560105);
            int3 b3 = int3(728539891, 480507742, 1696553040);
            bool3 r3 = bool3(false, false, false);
            TestUtils.AreEqual(a3 < b3, r3);
        }

        [Test]
        public void int3_operator_greater_wide_wide()
        {
            int3 a0 = int3(2087717754, 1725569452, 1298066182);
            int3 b0 = int3(85148514, 293632137, 1151128249);
            bool3 r0 = bool3(true, true, true);
            TestUtils.AreEqual(a0 > b0, r0);

            int3 a1 = int3(1693943616, 1319019629, 70674491);
            int3 b1 = int3(409440398, 1115020183, 1508500597);
            bool3 r1 = bool3(true, true, false);
            TestUtils.AreEqual(a1 > b1, r1);

            int3 a2 = int3(1042499725, 1002821508, 1021857133);
            int3 b2 = int3(1834583302, 1755218534, 1788761753);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 > b2, r2);

            int3 a3 = int3(1744374599, 821751047, 467646903);
            int3 b3 = int3(1128238489, 834223713, 1578743290);
            bool3 r3 = bool3(true, false, false);
            TestUtils.AreEqual(a3 > b3, r3);
        }

        [Test]
        public void int3_operator_greater_wide_scalar()
        {
            int3 a0 = int3(1208626274, 239697208, 1979453345);
            int b0 = (1715176566);
            bool3 r0 = bool3(false, false, true);
            TestUtils.AreEqual(a0 > b0, r0);

            int3 a1 = int3(1253474001, 1487911635, 1673945595);
            int b1 = (1590192876);
            bool3 r1 = bool3(false, false, true);
            TestUtils.AreEqual(a1 > b1, r1);

            int3 a2 = int3(1662650098, 1433540517, 566635217);
            int b2 = (222749855);
            bool3 r2 = bool3(true, true, true);
            TestUtils.AreEqual(a2 > b2, r2);

            int3 a3 = int3(1773305960, 206147145, 325913453);
            int b3 = (1850273578);
            bool3 r3 = bool3(false, false, false);
            TestUtils.AreEqual(a3 > b3, r3);
        }

        [Test]
        public void int3_operator_greater_scalar_wide()
        {
            int a0 = (480938827);
            int3 b0 = int3(1824731899, 921496110, 586859044);
            bool3 r0 = bool3(false, false, false);
            TestUtils.AreEqual(a0 > b0, r0);

            int a1 = (946430596);
            int3 b1 = int3(1231356727, 1390167458, 1785807092);
            bool3 r1 = bool3(false, false, false);
            TestUtils.AreEqual(a1 > b1, r1);

            int a2 = (28949024);
            int3 b2 = int3(2037899283, 595656760, 1778095771);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 > b2, r2);

            int a3 = (1233500439);
            int3 b3 = int3(1696302238, 1445965340, 484020151);
            bool3 r3 = bool3(false, false, true);
            TestUtils.AreEqual(a3 > b3, r3);
        }

        [Test]
        public void int3_operator_less_equal_wide_wide()
        {
            int3 a0 = int3(154092149, 1515170149, 1083970332);
            int3 b0 = int3(77984380, 1712054191, 1566203809);
            bool3 r0 = bool3(false, true, true);
            TestUtils.AreEqual(a0 <= b0, r0);

            int3 a1 = int3(785807178, 1401094881, 310537627);
            int3 b1 = int3(254834519, 450519938, 389457083);
            bool3 r1 = bool3(false, false, true);
            TestUtils.AreEqual(a1 <= b1, r1);

            int3 a2 = int3(868328962, 1990816725, 2035349541);
            int3 b2 = int3(1298669505, 207343167, 1214449047);
            bool3 r2 = bool3(true, false, false);
            TestUtils.AreEqual(a2 <= b2, r2);

            int3 a3 = int3(457043352, 1123282035, 1001842946);
            int3 b3 = int3(2059561026, 896534357, 1897470050);
            bool3 r3 = bool3(true, false, true);
            TestUtils.AreEqual(a3 <= b3, r3);
        }

        [Test]
        public void int3_operator_less_equal_wide_scalar()
        {
            int3 a0 = int3(1479531977, 1427983411, 415250630);
            int b0 = (2004563877);
            bool3 r0 = bool3(true, true, true);
            TestUtils.AreEqual(a0 <= b0, r0);

            int3 a1 = int3(1245345407, 1072990632, 1579912858);
            int b1 = (1112546666);
            bool3 r1 = bool3(false, true, false);
            TestUtils.AreEqual(a1 <= b1, r1);

            int3 a2 = int3(101048307, 509818792, 1910488590);
            int b2 = (1070894375);
            bool3 r2 = bool3(true, true, false);
            TestUtils.AreEqual(a2 <= b2, r2);

            int3 a3 = int3(85452501, 1246249980, 1097326500);
            int b3 = (518127023);
            bool3 r3 = bool3(true, false, false);
            TestUtils.AreEqual(a3 <= b3, r3);
        }

        [Test]
        public void int3_operator_less_equal_scalar_wide()
        {
            int a0 = (1899193992);
            int3 b0 = int3(915011820, 980913757, 1337699683);
            bool3 r0 = bool3(false, false, false);
            TestUtils.AreEqual(a0 <= b0, r0);

            int a1 = (1476321359);
            int3 b1 = int3(1102143668, 660493983, 184664508);
            bool3 r1 = bool3(false, false, false);
            TestUtils.AreEqual(a1 <= b1, r1);

            int a2 = (381579707);
            int3 b2 = int3(1954892821, 1295090571, 1440368586);
            bool3 r2 = bool3(true, true, true);
            TestUtils.AreEqual(a2 <= b2, r2);

            int a3 = (1696003686);
            int3 b3 = int3(88708652, 1332251857, 1310713644);
            bool3 r3 = bool3(false, false, false);
            TestUtils.AreEqual(a3 <= b3, r3);
        }

        [Test]
        public void int3_operator_greater_equal_wide_wide()
        {
            int3 a0 = int3(8538378, 2131749726, 265427108);
            int3 b0 = int3(903145828, 1697992986, 1432491982);
            bool3 r0 = bool3(false, true, false);
            TestUtils.AreEqual(a0 >= b0, r0);

            int3 a1 = int3(523609761, 994991818, 839709564);
            int3 b1 = int3(169789504, 1059357300, 1744255222);
            bool3 r1 = bool3(true, false, false);
            TestUtils.AreEqual(a1 >= b1, r1);

            int3 a2 = int3(101288202, 1886280970, 2032074826);
            int3 b2 = int3(1606584463, 1905414425, 1448794969);
            bool3 r2 = bool3(false, false, true);
            TestUtils.AreEqual(a2 >= b2, r2);

            int3 a3 = int3(631221455, 1456286159, 961342752);
            int3 b3 = int3(136181998, 1678754836, 2069656857);
            bool3 r3 = bool3(true, false, false);
            TestUtils.AreEqual(a3 >= b3, r3);
        }

        [Test]
        public void int3_operator_greater_equal_wide_scalar()
        {
            int3 a0 = int3(2049236663, 182691143, 634973382);
            int b0 = (1061998015);
            bool3 r0 = bool3(true, false, false);
            TestUtils.AreEqual(a0 >= b0, r0);

            int3 a1 = int3(1197012109, 1367606469, 1108037359);
            int b1 = (439837565);
            bool3 r1 = bool3(true, true, true);
            TestUtils.AreEqual(a1 >= b1, r1);

            int3 a2 = int3(351147187, 411667685, 1998610091);
            int b2 = (1898505669);
            bool3 r2 = bool3(false, false, true);
            TestUtils.AreEqual(a2 >= b2, r2);

            int3 a3 = int3(4652390, 2111455181, 727766399);
            int b3 = (996159180);
            bool3 r3 = bool3(false, true, false);
            TestUtils.AreEqual(a3 >= b3, r3);
        }

        [Test]
        public void int3_operator_greater_equal_scalar_wide()
        {
            int a0 = (1859811087);
            int3 b0 = int3(1070365918, 1783869452, 830091760);
            bool3 r0 = bool3(true, true, true);
            TestUtils.AreEqual(a0 >= b0, r0);

            int a1 = (377157428);
            int3 b1 = int3(327199016, 90384229, 1154649706);
            bool3 r1 = bool3(true, true, false);
            TestUtils.AreEqual(a1 >= b1, r1);

            int a2 = (376758501);
            int3 b2 = int3(1079802834, 2054742898, 1328349472);
            bool3 r2 = bool3(false, false, false);
            TestUtils.AreEqual(a2 >= b2, r2);

            int a3 = (434061447);
            int3 b3 = int3(951207723, 598695892, 975131651);
            bool3 r3 = bool3(false, false, false);
            TestUtils.AreEqual(a3 >= b3, r3);
        }

        [Test]
        public void int3_operator_add_wide_wide()
        {
            int3 a0 = int3(2135171378, 21433296, 1954723494);
            int3 b0 = int3(1013431952, 366718162, 359290756);
            int3 r0 = int3(-1146363966, 388151458, -1980953046);
            TestUtils.AreEqual(a0 + b0, r0);

            int3 a1 = int3(683604307, 1054212315, 1762680995);
            int3 b1 = int3(1393163294, 1962236872, 1263270041);
            int3 r1 = int3(2076767601, -1278518109, -1269016260);
            TestUtils.AreEqual(a1 + b1, r1);

            int3 a2 = int3(1963655852, 1257853062, 2043493600);
            int3 b2 = int3(1862666629, 1077447887, 821693806);
            int3 r2 = int3(-468644815, -1959666347, -1429779890);
            TestUtils.AreEqual(a2 + b2, r2);

            int3 a3 = int3(976898058, 1915056423, 121374462);
            int3 b3 = int3(487316539, 350922520, 1583012528);
            int3 r3 = int3(1464214597, -2028988353, 1704386990);
            TestUtils.AreEqual(a3 + b3, r3);
        }

        [Test]
        public void int3_operator_add_wide_scalar()
        {
            int3 a0 = int3(665815972, 1783729250, 1591678394);
            int b0 = (1334043849);
            int3 r0 = int3(1999859821, -1177194197, -1369245053);
            TestUtils.AreEqual(a0 + b0, r0);

            int3 a1 = int3(1284528538, 71069732, 1138577680);
            int b1 = (977850224);
            int3 r1 = int3(-2032588534, 1048919956, 2116427904);
            TestUtils.AreEqual(a1 + b1, r1);

            int3 a2 = int3(1200356017, 1246759684, 1088001167);
            int b2 = (565982008);
            int3 r2 = int3(1766338025, 1812741692, 1653983175);
            TestUtils.AreEqual(a2 + b2, r2);

            int3 a3 = int3(57252642, 625943813, 512157429);
            int b3 = (678921480);
            int3 r3 = int3(736174122, 1304865293, 1191078909);
            TestUtils.AreEqual(a3 + b3, r3);
        }

        [Test]
        public void int3_operator_add_scalar_wide()
        {
            int a0 = (359966320);
            int3 b0 = int3(2146146202, 767103309, 851002415);
            int3 r0 = int3(-1788854774, 1127069629, 1210968735);
            TestUtils.AreEqual(a0 + b0, r0);

            int a1 = (311531406);
            int3 b1 = int3(1491262941, 1016891373, 1954228994);
            int3 r1 = int3(1802794347, 1328422779, -2029206896);
            TestUtils.AreEqual(a1 + b1, r1);

            int a2 = (1671335850);
            int3 b2 = int3(727870747, 551151834, 1390261152);
            int3 r2 = int3(-1895760699, -2072479612, -1233370294);
            TestUtils.AreEqual(a2 + b2, r2);

            int a3 = (1699060326);
            int3 b3 = int3(115021619, 1964440175, 440700758);
            int3 r3 = int3(1814081945, -631466795, 2139761084);
            TestUtils.AreEqual(a3 + b3, r3);
        }

        [Test]
        public void int3_operator_sub_wide_wide()
        {
            int3 a0 = int3(1410318491, 1097280168, 1827039044);
            int3 b0 = int3(1315897366, 799052018, 1580289673);
            int3 r0 = int3(94421125, 298228150, 246749371);
            TestUtils.AreEqual(a0 - b0, r0);

            int3 a1 = int3(28881338, 328720965, 875487868);
            int3 b1 = int3(1094686261, 1954325726, 1197734816);
            int3 r1 = int3(-1065804923, -1625604761, -322246948);
            TestUtils.AreEqual(a1 - b1, r1);

            int3 a2 = int3(212936325, 231977215, 1740021315);
            int3 b2 = int3(229886366, 915679176, 1746884850);
            int3 r2 = int3(-16950041, -683701961, -6863535);
            TestUtils.AreEqual(a2 - b2, r2);

            int3 a3 = int3(2011295463, 48079003, 591379285);
            int3 b3 = int3(918743925, 1007797419, 257421324);
            int3 r3 = int3(1092551538, -959718416, 333957961);
            TestUtils.AreEqual(a3 - b3, r3);
        }

        [Test]
        public void int3_operator_sub_wide_scalar()
        {
            int3 a0 = int3(1508669340, 1594795463, 266707545);
            int b0 = (998008471);
            int3 r0 = int3(510660869, 596786992, -731300926);
            TestUtils.AreEqual(a0 - b0, r0);

            int3 a1 = int3(643102647, 1475644328, 1113286221);
            int b1 = (287705008);
            int3 r1 = int3(355397639, 1187939320, 825581213);
            TestUtils.AreEqual(a1 - b1, r1);

            int3 a2 = int3(979450511, 1108005498, 304369206);
            int b2 = (2082174113);
            int3 r2 = int3(-1102723602, -974168615, -1777804907);
            TestUtils.AreEqual(a2 - b2, r2);

            int3 a3 = int3(999244508, 1994553647, 2101812429);
            int b3 = (1806482044);
            int3 r3 = int3(-807237536, 188071603, 295330385);
            TestUtils.AreEqual(a3 - b3, r3);
        }

        [Test]
        public void int3_operator_sub_scalar_wide()
        {
            int a0 = (893369501);
            int3 b0 = int3(2051906184, 1699714311, 442603706);
            int3 r0 = int3(-1158536683, -806344810, 450765795);
            TestUtils.AreEqual(a0 - b0, r0);

            int a1 = (1735141684);
            int3 b1 = int3(274533585, 811580259, 1196354320);
            int3 r1 = int3(1460608099, 923561425, 538787364);
            TestUtils.AreEqual(a1 - b1, r1);

            int a2 = (1524097023);
            int3 b2 = int3(533621527, 2080845793, 143958837);
            int3 r2 = int3(990475496, -556748770, 1380138186);
            TestUtils.AreEqual(a2 - b2, r2);

            int a3 = (1620668660);
            int3 b3 = int3(1135989346, 1367044745, 554088609);
            int3 r3 = int3(484679314, 253623915, 1066580051);
            TestUtils.AreEqual(a3 - b3, r3);
        }

        [Test]
        public void int3_operator_mul_wide_wide()
        {
            int3 a0 = int3(61417577, 219585476, 1362520891);
            int3 b0 = int3(578042444, 1620527213, 200516468);
            int3 r0 = int3(-1426863828, 1326150260, -990894148);
            TestUtils.AreEqual(a0 * b0, r0);

            int3 a1 = int3(1511084277, 1481211272, 58211871);
            int3 b1 = int3(309339115, 542853019, 299467282);
            int3 r1 = int3(-1322856473, 1973926232, 88546350);
            TestUtils.AreEqual(a1 * b1, r1);

            int3 a2 = int3(1459591173, 567624644, 1169935583);
            int3 b2 = int3(1479641221, 1428338601, 1497302909);
            int3 r2 = int3(-863919463, -582821788, 556671459);
            TestUtils.AreEqual(a2 * b2, r2);

            int3 a3 = int3(1835691886, 385626539, 85934842);
            int3 b3 = int3(1596889147, 427413842, 265122693);
            int3 r3 = int3(1098186330, 1848083398, -58320414);
            TestUtils.AreEqual(a3 * b3, r3);
        }

        [Test]
        public void int3_operator_mul_wide_scalar()
        {
            int3 a0 = int3(871746615, 492532311, 570557670);
            int b0 = (442064533);
            int3 r0 = int3(338365955, 1081376419, -1729147426);
            TestUtils.AreEqual(a0 * b0, r0);

            int3 a1 = int3(2142306629, 1526163563, 118471734);
            int b1 = (1610315153);
            int3 r1 = int3(310198549, -1362883685, -1008711530);
            TestUtils.AreEqual(a1 * b1, r1);

            int3 a2 = int3(257439514, 1186560810, 1584938026);
            int b2 = (364291059);
            int3 r2 = int3(172874670, 1029154526, 1917573598);
            TestUtils.AreEqual(a2 * b2, r2);

            int3 a3 = int3(1357601203, 268562104, 1007838321);
            int b3 = (638897141);
            int3 r3 = int3(-1520842417, -796565992, -1307329755);
            TestUtils.AreEqual(a3 * b3, r3);
        }

        [Test]
        public void int3_operator_mul_scalar_wide()
        {
            int a0 = (1152242766);
            int3 b0 = int3(1276636134, 2105929407, 499007702);
            int3 r0 = int3(-2129504236, 999811634, 1179056436);
            TestUtils.AreEqual(a0 * b0, r0);

            int a1 = (124002565);
            int3 b1 = int3(1956335172, 1288034953, 832676555);
            int3 r1 = int3(-1162917036, 495775149, -227518217);
            TestUtils.AreEqual(a1 * b1, r1);

            int a2 = (337389733);
            int3 b2 = int3(99268757, 2005055247, 2011389505);
            int3 r2 = int3(1366048777, -1518447445, 794945509);
            TestUtils.AreEqual(a2 * b2, r2);

            int a3 = (1348110859);
            int3 b3 = int3(399689191, 2007606374, 2076691289);
            int3 r3 = int3(1743980269, 1120210018, 1383970515);
            TestUtils.AreEqual(a3 * b3, r3);
        }

        [Test]
        public void int3_operator_div_wide_wide()
        {
            int3 a0 = int3(333171510, 858154903, 1181365836);
            int3 b0 = int3(698897823, 440199998, 655557473);
            int3 r0 = int3(0, 1, 1);
            TestUtils.AreEqual(a0 / b0, r0);

            int3 a1 = int3(671357749, 1090606752, 803759420);
            int3 b1 = int3(1658534285, 2127220100, 315653188);
            int3 r1 = int3(0, 0, 2);
            TestUtils.AreEqual(a1 / b1, r1);

            int3 a2 = int3(788404166, 296807814, 575260195);
            int3 b2 = int3(1814290360, 992173243, 914851653);
            int3 r2 = int3(0, 0, 0);
            TestUtils.AreEqual(a2 / b2, r2);

            int3 a3 = int3(166625280, 1493729000, 1831739736);
            int3 b3 = int3(664340325, 224323977, 246981573);
            int3 r3 = int3(0, 6, 7);
            TestUtils.AreEqual(a3 / b3, r3);
        }

        [Test]
        public void int3_operator_div_wide_scalar()
        {
            int3 a0 = int3(1433072926, 1073958635, 1195142312);
            int b0 = (1434025872);
            int3 r0 = int3(0, 0, 0);
            TestUtils.AreEqual(a0 / b0, r0);

            int3 a1 = int3(536596719, 464756346, 806462546);
            int b1 = (1274375693);
            int3 r1 = int3(0, 0, 0);
            TestUtils.AreEqual(a1 / b1, r1);

            int3 a2 = int3(906504670, 25493909, 1196815948);
            int b2 = (1380905136);
            int3 r2 = int3(0, 0, 0);
            TestUtils.AreEqual(a2 / b2, r2);

            int3 a3 = int3(123300377, 2084019932, 2047825037);
            int b3 = (643754735);
            int3 r3 = int3(0, 3, 3);
            TestUtils.AreEqual(a3 / b3, r3);
        }

        [Test]
        public void int3_operator_div_scalar_wide()
        {
            int a0 = (519165704);
            int3 b0 = int3(1295178177, 775214121, 467772046);
            int3 r0 = int3(0, 0, 1);
            TestUtils.AreEqual(a0 / b0, r0);

            int a1 = (1156881598);
            int3 b1 = int3(310396565, 759759959, 243837702);
            int3 r1 = int3(3, 1, 4);
            TestUtils.AreEqual(a1 / b1, r1);

            int a2 = (1616314235);
            int3 b2 = int3(1053470225, 1320630160, 378773841);
            int3 r2 = int3(1, 1, 4);
            TestUtils.AreEqual(a2 / b2, r2);

            int a3 = (4223608);
            int3 b3 = int3(1971105754, 2054406020, 219939614);
            int3 r3 = int3(0, 0, 0);
            TestUtils.AreEqual(a3 / b3, r3);
        }

        [Test]
        public void int3_operator_mod_wide_wide()
        {
            int3 a0 = int3(258342924, 1454754891, 723352342);
            int3 b0 = int3(1990080167, 1197348066, 651970512);
            int3 r0 = int3(258342924, 257406825, 71381830);
            TestUtils.AreEqual(a0 % b0, r0);

            int3 a1 = int3(1981431473, 531756042, 716993627);
            int3 b1 = int3(1659454050, 241005212, 1866255454);
            int3 r1 = int3(321977423, 49745618, 716993627);
            TestUtils.AreEqual(a1 % b1, r1);

            int3 a2 = int3(1667903349, 1331097004, 1776856101);
            int3 b2 = int3(1440101415, 595220963, 408818410);
            int3 r2 = int3(227801934, 140655078, 141582461);
            TestUtils.AreEqual(a2 % b2, r2);

            int3 a3 = int3(17598216, 1474345080, 1681376293);
            int3 b3 = int3(198222574, 549504274, 239973807);
            int3 r3 = int3(17598216, 375336532, 1559644);
            TestUtils.AreEqual(a3 % b3, r3);
        }

        [Test]
        public void int3_operator_mod_wide_scalar()
        {
            int3 a0 = int3(560988938, 629524514, 767711194);
            int b0 = (1156862367);
            int3 r0 = int3(560988938, 629524514, 767711194);
            TestUtils.AreEqual(a0 % b0, r0);

            int3 a1 = int3(434281967, 792916846, 1663690927);
            int b1 = (1399805893);
            int3 r1 = int3(434281967, 792916846, 263885034);
            TestUtils.AreEqual(a1 % b1, r1);

            int3 a2 = int3(598661916, 1287035793, 1743722161);
            int b2 = (1776636144);
            int3 r2 = int3(598661916, 1287035793, 1743722161);
            TestUtils.AreEqual(a2 % b2, r2);

            int3 a3 = int3(475209785, 1617696916, 379853074);
            int b3 = (327476870);
            int3 r3 = int3(147732915, 307789436, 52376204);
            TestUtils.AreEqual(a3 % b3, r3);
        }

        [Test]
        public void int3_operator_mod_scalar_wide()
        {
            int a0 = (933347930);
            int3 b0 = int3(549923387, 243114953, 1884274390);
            int3 r0 = int3(383424543, 204003071, 933347930);
            TestUtils.AreEqual(a0 % b0, r0);

            int a1 = (1428033594);
            int3 b1 = int3(655531454, 1622674954, 1107563514);
            int3 r1 = int3(116970686, 1428033594, 320470080);
            TestUtils.AreEqual(a1 % b1, r1);

            int a2 = (1614111094);
            int3 b2 = int3(914801920, 1432263179, 564431096);
            int3 r2 = int3(699309174, 181847915, 485248902);
            TestUtils.AreEqual(a2 % b2, r2);

            int a3 = (1967013901);
            int3 b3 = int3(1709750152, 1080102613, 13120773);
            int3 r3 = int3(257263749, 886911288, 12018724);
            TestUtils.AreEqual(a3 % b3, r3);
        }

        [Test]
        public void int3_operator_plus()
        {
            int3 a0 = int3(195392567, 222719748, 1002351013);
            int3 r0 = int3(195392567, 222719748, 1002351013);
            TestUtils.AreEqual(+a0, r0);

            int3 a1 = int3(1570765263, 1515950277, 1689763402);
            int3 r1 = int3(1570765263, 1515950277, 1689763402);
            TestUtils.AreEqual(+a1, r1);

            int3 a2 = int3(291471785, 1084131995, 195779102);
            int3 r2 = int3(291471785, 1084131995, 195779102);
            TestUtils.AreEqual(+a2, r2);

            int3 a3 = int3(2131702223, 1995564647, 69731564);
            int3 r3 = int3(2131702223, 1995564647, 69731564);
            TestUtils.AreEqual(+a3, r3);
        }

        [Test]
        public void int3_operator_neg()
        {
            int3 a0 = int3(1385088677, 94114564, 1350664872);
            int3 r0 = int3(-1385088677, -94114564, -1350664872);
            TestUtils.AreEqual(-a0, r0);

            int3 a1 = int3(1458616659, 218122493, 958484951);
            int3 r1 = int3(-1458616659, -218122493, -958484951);
            TestUtils.AreEqual(-a1, r1);

            int3 a2 = int3(270553961, 270503114, 1928771252);
            int3 r2 = int3(-270553961, -270503114, -1928771252);
            TestUtils.AreEqual(-a2, r2);

            int3 a3 = int3(1427605822, 1434247484, 485368391);
            int3 r3 = int3(-1427605822, -1434247484, -485368391);
            TestUtils.AreEqual(-a3, r3);
        }

        [Test]
        public void int3_operator_prefix_inc()
        {
            int3 a0 = int3(780471723, 954741756, 272723451);
            int3 r0 = int3(780471724, 954741757, 272723452);
            TestUtils.AreEqual(++a0, r0);

            int3 a1 = int3(2142862245, 1514814550, 250124151);
            int3 r1 = int3(2142862246, 1514814551, 250124152);
            TestUtils.AreEqual(++a1, r1);

            int3 a2 = int3(444189162, 1915989169, 1348278302);
            int3 r2 = int3(444189163, 1915989170, 1348278303);
            TestUtils.AreEqual(++a2, r2);

            int3 a3 = int3(129540735, 1170613526, 986715680);
            int3 r3 = int3(129540736, 1170613527, 986715681);
            TestUtils.AreEqual(++a3, r3);
        }

        [Test]
        public void int3_operator_postfix_inc()
        {
            int3 a0 = int3(241865086, 2145821641, 1596166022);
            int3 r0 = int3(241865086, 2145821641, 1596166022);
            TestUtils.AreEqual(a0++, r0);

            int3 a1 = int3(803592338, 1656767229, 903047443);
            int3 r1 = int3(803592338, 1656767229, 903047443);
            TestUtils.AreEqual(a1++, r1);

            int3 a2 = int3(1213663244, 1384002775, 389844650);
            int3 r2 = int3(1213663244, 1384002775, 389844650);
            TestUtils.AreEqual(a2++, r2);

            int3 a3 = int3(1159795446, 1227160199, 947635082);
            int3 r3 = int3(1159795446, 1227160199, 947635082);
            TestUtils.AreEqual(a3++, r3);
        }

        [Test]
        public void int3_operator_prefix_dec()
        {
            int3 a0 = int3(1331961415, 1612382200, 1401591249);
            int3 r0 = int3(1331961414, 1612382199, 1401591248);
            TestUtils.AreEqual(--a0, r0);

            int3 a1 = int3(2042075388, 1895858159, 1467742422);
            int3 r1 = int3(2042075387, 1895858158, 1467742421);
            TestUtils.AreEqual(--a1, r1);

            int3 a2 = int3(578341664, 2059077641, 1169239112);
            int3 r2 = int3(578341663, 2059077640, 1169239111);
            TestUtils.AreEqual(--a2, r2);

            int3 a3 = int3(1862369220, 1027543764, 1595492535);
            int3 r3 = int3(1862369219, 1027543763, 1595492534);
            TestUtils.AreEqual(--a3, r3);
        }

        [Test]
        public void int3_operator_postfix_dec()
        {
            int3 a0 = int3(1870005937, 1708534798, 704493460);
            int3 r0 = int3(1870005937, 1708534798, 704493460);
            TestUtils.AreEqual(a0--, r0);

            int3 a1 = int3(462940703, 228744869, 940247280);
            int3 r1 = int3(462940703, 228744869, 940247280);
            TestUtils.AreEqual(a1--, r1);

            int3 a2 = int3(1818778351, 862428933, 1401191870);
            int3 r2 = int3(1818778351, 862428933, 1401191870);
            TestUtils.AreEqual(a2--, r2);

            int3 a3 = int3(2080259851, 140452688, 1928164223);
            int3 r3 = int3(2080259851, 140452688, 1928164223);
            TestUtils.AreEqual(a3--, r3);
        }

        [Test]
        public void int3_operator_bitwise_and_wide_wide()
        {
            int3 a0 = int3(1055241304, 859321394, 1088358961);
            int3 b0 = int3(749698416, 748105424, 1842764797);
            int3 r0 = int3(749024336, 537928720, 1087769137);
            TestUtils.AreEqual(a0 & b0, r0);

            int3 a1 = int3(2090949513, 300561740, 651904515);
            int3 b1 = int3(9990577, 1989102105, 1666634755);
            int3 r1 = int3(8409473, 277479432, 575816707);
            TestUtils.AreEqual(a1 & b1, r1);

            int3 a2 = int3(1331035868, 2012752753, 1298126656);
            int3 b2 = int3(58116798, 868036607, 1420638875);
            int3 r2 = int3(55888540, 867707761, 1141707264);
            TestUtils.AreEqual(a2 & b2, r2);

            int3 a3 = int3(53199569, 1752363533, 1303061302);
            int3 b3 = int3(1308767169, 564040763, 478617502);
            int3 r3 = int3(33686209, 538087433, 209912598);
            TestUtils.AreEqual(a3 & b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_and_wide_scalar()
        {
            int3 a0 = int3(1513158868, 284695609, 734595037);
            int b0 = (1173647397);
            int3 r0 = int3(1076916228, 15732769, 29360133);
            TestUtils.AreEqual(a0 & b0, r0);

            int3 a1 = int3(1566510707, 84213838, 314333543);
            int b1 = (1601252476);
            int3 r1 = int3(1565592688, 83951692, 305137764);
            TestUtils.AreEqual(a1 & b1, r1);

            int3 a2 = int3(430856908, 327392481, 1619794917);
            int b2 = (753481263);
            int3 r2 = int3(145232396, 8459297, 545788453);
            TestUtils.AreEqual(a2 & b2, r2);

            int3 a3 = int3(2143619546, 126982769, 651482651);
            int b3 = (1873208293);
            int3 r3 = int3(1870922176, 125862497, 646234625);
            TestUtils.AreEqual(a3 & b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_and_scalar_wide()
        {
            int a0 = (477163326);
            int3 b0 = int3(110453385, 703240362, 2075630560);
            int3 r0 = int3(68182536, 140544042, 405834528);
            TestUtils.AreEqual(a0 & b0, r0);

            int a1 = (1884904031);
            int3 b1 = int3(1734899436, 947945203, 1664399051);
            int3 r1 = int3(1615352396, 805329491, 1611665995);
            TestUtils.AreEqual(a1 & b1, r1);

            int a2 = (458879298);
            int3 b2 = int3(158491426, 79772356, 2054527944);
            int3 r2 = int3(156262658, 4272192, 441553216);
            TestUtils.AreEqual(a2 & b2, r2);

            int a3 = (202228212);
            int3 b3 = int3(359225061, 639811396, 1821945318);
            int3 r3 = int3(67715300, 67141956, 201884132);
            TestUtils.AreEqual(a3 & b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_or_wide_wide()
        {
            int3 a0 = int3(1920951869, 1750772852, 1420019191);
            int3 b0 = int3(214585254, 275414367, 858759675);
            int3 r0 = int3(2130669503, 2021326207, 2008016383);
            TestUtils.AreEqual(a0 | b0, r0);

            int3 a1 = int3(732977093, 1169579447, 229437930);
            int3 b1 = int3(190211455, 1218691723, 2129565457);
            int3 r1 = int3(737572863, 1303895999, 2146367483);
            TestUtils.AreEqual(a1 | b1, r1);

            int3 a2 = int3(1966721348, 2039812323, 113550869);
            int3 b2 = int3(1862809466, 495728846, 868064152);
            int3 r2 = int3(2134507390, 2107455727, 939376541);
            TestUtils.AreEqual(a2 | b2, r2);

            int3 a3 = int3(1912038362, 1569990624, 1490718227);
            int3 b3 = int3(1756913766, 933656055, 247722084);
            int3 r3 = int3(2046780414, 2142664695, 1591475831);
            TestUtils.AreEqual(a3 | b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_or_wide_scalar()
        {
            int3 a0 = int3(1295304853, 1307252624, 350194630);
            int b0 = (1305527136);
            int3 r0 = int3(1307888629, 1308350448, 1574947814);
            TestUtils.AreEqual(a0 | b0, r0);

            int3 a1 = int3(1128063578, 2085245467, 1988423804);
            int b1 = (1774824542);
            int3 r1 = int3(1811803742, 2110520927, 2144205950);
            TestUtils.AreEqual(a1 | b1, r1);

            int3 a2 = int3(999162350, 1050875188, 341855232);
            int b2 = (2110327307);
            int3 r2 = int3(2144275439, 2146115391, 2112441867);
            TestUtils.AreEqual(a2 | b2, r2);

            int3 a3 = int3(1317039676, 41280811, 1536908787);
            int b3 = (228656898);
            int3 r3 = int3(1335979838, 267773739, 1606115315);
            TestUtils.AreEqual(a3 | b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_or_scalar_wide()
        {
            int a0 = (1768627592);
            int3 b0 = int3(1849658052, 1759912154, 729979455);
            int3 r0 = int3(1870634956, 1777286618, 1810603967);
            TestUtils.AreEqual(a0 | b0, r0);

            int a1 = (975926310);
            int3 b1 = int3(1987690876, 1809506714, 1160695341);
            int3 r1 = int3(2122052990, 2080110014, 2133851695);
            TestUtils.AreEqual(a1 | b1, r1);

            int a2 = (408963395);
            int3 b2 = int3(314072711, 1560007537, 1709003416);
            int3 r2 = int3(452485063, 1560009587, 2113756123);
            TestUtils.AreEqual(a2 | b2, r2);

            int a3 = (977086639);
            int3 b3 = int3(1448375596, 1689568808, 595543345);
            int3 r3 = int3(2122153391, 2126376623, 998206911);
            TestUtils.AreEqual(a3 | b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_xor_wide_wide()
        {
            int3 a0 = int3(1843655608, 362425681, 640805534);
            int3 b0 = int3(1422803441, 1234691140, 119589253);
            int3 r0 = int3(959296073, 1544407317, 554771227);
            TestUtils.AreEqual(a0 ^ b0, r0);

            int3 a1 = int3(1342040268, 945678755, 980321850);
            int3 b1 = int3(1101464929, 121896337, 1880109018);
            int3 r1 = int3(240840109, 1058935858, 1249815008);
            TestUtils.AreEqual(a1 ^ b1, r1);

            int3 a2 = int3(390165019, 1682422658, 303897251);
            int3 b2 = int3(1000210266, 1718938232, 464406940);
            int3 r2 = int3(752651585, 36917754, 162747199);
            TestUtils.AreEqual(a2 ^ b2, r2);

            int3 a3 = int3(230477768, 1103646442, 1503102919);
            int3 b3 = int3(884337881, 34199854, 1430659227);
            int3 r3 = int3(956900113, 1136760772, 215066460);
            TestUtils.AreEqual(a3 ^ b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_xor_wide_scalar()
        {
            int3 a0 = int3(169345668, 176087064, 2084362901);
            int b0 = (354464228);
            int3 r0 = int3(523809632, 526275068, 1763470193);
            TestUtils.AreEqual(a0 ^ b0, r0);

            int3 a1 = int3(1663924004, 517476661, 905336222);
            int b1 = (193851255);
            int3 r1 = int3(1755355219, 357957186, 1048296169);
            TestUtils.AreEqual(a1 ^ b1, r1);

            int3 a2 = int3(863800783, 835837496, 954341348);
            int b2 = (365003873);
            int3 r2 = int3(649922990, 605051481, 757306245);
            TestUtils.AreEqual(a2 ^ b2, r2);

            int3 a3 = int3(1464576786, 1700827127, 2003392824);
            int b3 = (625604047);
            int3 r3 = int3(1912757981, 1076460088, 1377873143);
            TestUtils.AreEqual(a3 ^ b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_xor_scalar_wide()
        {
            int a0 = (1361775641);
            int3 b0 = int3(1452773578, 459050892, 1986218254);
            int3 r0 = int3(129801427, 1249346453, 659047703);
            TestUtils.AreEqual(a0 ^ b0, r0);

            int a1 = (1689037698);
            int3 b1 = int3(999278344, 1229114508, 1087843538);
            int3 r1 = int3(1596157066, 770598670, 612075344);
            TestUtils.AreEqual(a1 ^ b1, r1);

            int a2 = (733699740);
            int3 b2 = int3(106187872, 1533632738, 1107817672);
            int3 r2 = int3(770642684, 1892826750, 1773972052);
            TestUtils.AreEqual(a2 ^ b2, r2);

            int a3 = (492506236);
            int3 b3 = int3(597602329, 1439603382, 1001169118);
            int3 r3 = int3(1053146213, 1217763018, 653765794);
            TestUtils.AreEqual(a3 ^ b3, r3);
        }

        [Test]
        public void int3_operator_left_shift()
        {
            int3 a0 = int3(1129100049, 829482269, 1571297368);
            int b0 = (218351941);
            int3 r0 = int3(1771463200, 773628832, -1258091776);
            TestUtils.AreEqual(a0 << b0, r0);

            int3 a1 = int3(443753193, 249554593, 892627436);
            int b1 = (1872142968);
            int3 r1 = int3(-385875968, -1593835520, -335544320);
            TestUtils.AreEqual(a1 << b1, r1);

            int3 a2 = int3(980302862, 849916599, 1271350845);
            int b2 = (62369727);
            int3 r2 = int3(0, -2147483648, -2147483648);
            TestUtils.AreEqual(a2 << b2, r2);

            int3 a3 = int3(108441902, 1779118882, 1451674188);
            int b3 = (1959056531);
            int3 r3 = int3(-1989148672, -1727004672, 1382023168);
            TestUtils.AreEqual(a3 << b3, r3);
        }

        [Test]
        public void int3_operator_right_shift()
        {
            int3 a0 = int3(809126085, 908563670, 763568837);
            int b0 = (994800051);
            int3 r0 = int3(1543, 1732, 1456);
            TestUtils.AreEqual(a0 >> b0, r0);

            int3 a1 = int3(1986717290, 646821842, 1242726074);
            int b1 = (1174507510);
            int3 r1 = int3(473, 154, 296);
            TestUtils.AreEqual(a1 >> b1, r1);

            int3 a2 = int3(390811632, 1923166649, 102096936);
            int b2 = (1521420393);
            int3 r2 = int3(763303, 3756184, 199408);
            TestUtils.AreEqual(a2 >> b2, r2);

            int3 a3 = int3(400863878, 1611921244, 307750782);
            int b3 = (667378673);
            int3 r3 = int3(3058, 12297, 2347);
            TestUtils.AreEqual(a3 >> b3, r3);
        }

        [Test]
        public void int3_operator_bitwise_not()
        {
            int3 a0 = int3(111796841, 603562399, 745091931);
            int3 r0 = int3(-111796842, -603562400, -745091932);
            TestUtils.AreEqual(~a0, r0);

            int3 a1 = int3(853183268, 381888399, 1891338755);
            int3 r1 = int3(-853183269, -381888400, -1891338756);
            TestUtils.AreEqual(~a1, r1);

            int3 a2 = int3(1506860135, 787710759, 875964607);
            int3 r2 = int3(-1506860136, -787710760, -875964608);
            TestUtils.AreEqual(~a2, r2);

            int3 a3 = int3(96456785, 203444882, 1172294211);
            int3 r3 = int3(-96456786, -203444883, -1172294212);
            TestUtils.AreEqual(~a3, r3);
        }

        [Test]
        public void int3_shuffle_result_1()
        {
            int3 a = int3(0, 1, 2);
            int3 b = int3(3, 4, 5);

            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftX), (0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY), (1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ), (2));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightX), (3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY), (4));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ), (5));
        }

        [Test]
        public void int3_shuffle_result_2()
        {
            int3 a = int3(0, 1, 2);
            int3 b = int3(3, 4, 5);

            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightY), int2(4, 4));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightX), int2(4, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY, ShuffleComponent.RightX), int2(1, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.LeftZ), int2(5, 2));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.LeftY), int2(5, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY, ShuffleComponent.LeftZ), int2(1, 2));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightX, ShuffleComponent.LeftZ), int2(3, 2));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.LeftX), int2(5, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.RightZ), int2(5, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftY), int2(4, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightZ), int2(4, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.LeftX), int2(5, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightX), int2(4, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.RightY), int2(5, 4));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightX, ShuffleComponent.LeftX), int2(3, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY, ShuffleComponent.LeftZ), int2(1, 2));
        }

        [Test]
        public void int3_shuffle_result_3()
        {
            int3 a = int3(0, 1, 2);
            int3 b = int3(3, 4, 5);

            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY, ShuffleComponent.RightZ, ShuffleComponent.RightX), int3(1, 5, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftX, ShuffleComponent.LeftZ), int3(4, 0, 2));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.RightX), int3(2, 5, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftX, ShuffleComponent.LeftY), int3(4, 0, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.RightY, ShuffleComponent.LeftZ), int3(5, 4, 2));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ, ShuffleComponent.LeftX, ShuffleComponent.LeftY), int3(2, 0, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ, ShuffleComponent.RightY, ShuffleComponent.RightX), int3(2, 4, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ, ShuffleComponent.LeftY, ShuffleComponent.RightZ), int3(2, 1, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightY, ShuffleComponent.RightZ), int3(4, 4, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightX, ShuffleComponent.LeftY), int3(4, 3, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.RightZ, ShuffleComponent.LeftX), int3(5, 5, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.LeftY, ShuffleComponent.RightX), int3(5, 1, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftY, ShuffleComponent.RightZ), int3(4, 1, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ, ShuffleComponent.RightX, ShuffleComponent.RightY), int3(2, 3, 4));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftX, ShuffleComponent.RightY), int3(4, 0, 4));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftX, ShuffleComponent.RightZ), int3(4, 0, 5));
        }

        [Test]
        public void int3_shuffle_result_4()
        {
            int3 a = int3(0, 1, 2);
            int3 b = int3(3, 4, 5);

            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY, ShuffleComponent.LeftZ, ShuffleComponent.RightX, ShuffleComponent.LeftY), int4(1, 2, 3, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.RightY), int4(4, 2, 5, 4));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightY, ShuffleComponent.RightZ, ShuffleComponent.LeftY), int4(4, 4, 5, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightX, ShuffleComponent.RightX, ShuffleComponent.LeftY, ShuffleComponent.LeftY), int4(3, 3, 1, 1));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftY, ShuffleComponent.LeftY, ShuffleComponent.LeftX), int4(4, 1, 1, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightX, ShuffleComponent.RightY, ShuffleComponent.RightX, ShuffleComponent.RightZ), int4(3, 4, 3, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY, ShuffleComponent.RightZ, ShuffleComponent.LeftX, ShuffleComponent.RightZ), int4(1, 5, 0, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.LeftX, ShuffleComponent.LeftX, ShuffleComponent.LeftX), int4(4, 0, 0, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightX, ShuffleComponent.RightZ, ShuffleComponent.LeftZ, ShuffleComponent.LeftX), int4(3, 5, 2, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightY, ShuffleComponent.RightX, ShuffleComponent.LeftY, ShuffleComponent.RightX), int4(4, 3, 1, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftX, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.LeftX), int4(0, 2, 5, 0));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftY, ShuffleComponent.RightY, ShuffleComponent.RightZ, ShuffleComponent.RightZ), int4(1, 4, 5, 5));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ, ShuffleComponent.RightX, ShuffleComponent.LeftY, ShuffleComponent.RightX), int4(2, 3, 1, 3));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightX, ShuffleComponent.LeftX, ShuffleComponent.LeftY, ShuffleComponent.LeftZ), int4(3, 0, 1, 2));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.RightZ, ShuffleComponent.RightX, ShuffleComponent.LeftX, ShuffleComponent.RightY), int4(5, 3, 0, 4));
            TestUtils.AreEqual(shuffle(a, b, ShuffleComponent.LeftZ, ShuffleComponent.RightZ, ShuffleComponent.LeftX, ShuffleComponent.RightY), int4(2, 5, 0, 4));
        }


    }
}
