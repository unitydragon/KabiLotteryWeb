using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KabiLottery2.Models;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace KabiLottery2.Controllers
{
    public class GameController : ApiController
    {
        GameApp[] answers = new GameApp[]
        {
            new GameApp{Id=1,Name="kabi",Comment="song" },
            new GameApp{Id=2,Name="pay",Comment="wing"}
        };
        [HttpGet]
        [ActionName("get")]
        public IEnumerable<GameApp> GetAllGame()
        {
            return answers;
        }
        [HttpGet]
        [ActionName("get")]
        public IHttpActionResult GetGame(int id)
        {
            var answer = answers.FirstOrDefault((p) => p.Id == id);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }
        [HttpGet]
        [ActionName("start")]
        public string Chance(string id)
        {
            try
            {
                //建立SqlConnectionStringBuilder
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "kabiwin.database.windows.net";
                scsb.InitialCatalog = "kabiwang";
                scsb.UserID = "kabi";
                scsb.Password = "Leo5544720";

                //建立Entities，並設定連線字串
                kabiwangEntities ef = new kabiwangEntities();
                ef.Database.Connection.ConnectionString = scsb.ConnectionString;

                var chance = ef.UserId.FirstOrDefault(n => n.Name == id);
                chance.Chance -= 1;
                chance.Datetime = DateTime.Now.ToLocalTime();
                ef.SaveChanges();

                return "還有" + chance.Chance.ToString() + "次抽獎機會";
            }
            catch
            {
                return "呵呵，找帥氣的工程師debug start";
            }

        }
        [HttpPost]
        [ActionName("wow")]
        public string VerifyAnswer(GameApp Ans)
        {
            try
            {
                //建立SqlConnectionStringBuilder
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = "kabiwin.database.windows.net";
                scsb.InitialCatalog = "kabiwang";
                scsb.UserID = "kabi";
                scsb.Password = "Leo5544720";

                //建立Entities，並設定連線字串
                kabiwangEntities ef = new kabiwangEntities();
                ef.Database.Connection.ConnectionString = scsb.ConnectionString;

                int? chance = 0;

                var lottery = ef.UserId.FirstOrDefault(k => k.Name == Ans.Name).Chance;

                if (lottery < 1)
                    return "沒有抽獎次數兄DEI";
                else
                    chance = lottery;

                var name = ef.UserId
                             .FirstOrDefault(b => b.Name.ToUpper() == Ans.Name.ToUpper() && b.LotteryName != true);

                var myname = ef.UserId
                               .FirstOrDefault(b => b.Myname.ToUpper() == Ans.Myname.ToUpper() && b.LotteryMyName != true);

                var comment = ef.UserId
                                .FirstOrDefault(b => b.Name.ToUpper() == Ans.Name.ToUpper() && b.LotteryMyName != true);
                var changeChance = ef.UserId
                                     .FirstOrDefault(n => n.Name.ToUpper() == Ans.Name.ToUpper());

                ChangeEF(ref chance, name, myname, comment, changeChance, ef);

                return chance.ToString();
            }
            catch
            {
                return "呵呵，找帥氣的工程師debug wow";
            }
        }
        [HttpPost]
        [ActionName("yoyo")]
        public string UpdateCommet(GameApp ans)
        {
            //建立SqlConnectionStringBuilder
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "kabiwin.database.windows.net";
            scsb.InitialCatalog = "kabiwang";
            scsb.UserID = "kabi";
            scsb.Password = "Leo5544720";

            //建立Entities，並設定連線字串
            kabiwangEntities ef = new kabiwangEntities();
            ef.Database.Connection.ConnectionString = scsb.ConnectionString;

            //更新從網頁上來的意見
            try
            {
                var GreatComment = ef.UserId.FirstOrDefault(n => n.Name.ToUpper() == ans.Name.ToUpper());
                GreatComment.Comment = ans.Comment;
                GreatComment.Datetime = DateTime.Now.ToLocalTime();
                ef.SaveChanges();
            }
            catch
            {
                return "抽獎名單沒有泥哦";
            }

            return "OOOOOOOOOK";
        }
        [HttpPost]
        [ActionName("hehe")]
        public string InsertGift(Gift gift)
        {
            //建立SqlConnectionStringBuilder
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "kabiwin.database.windows.net";
            scsb.InitialCatalog = "kabiwang";
            scsb.UserID = "kabi";
            scsb.Password = "Leo5544720";

            //建立Entities，並設定連線字串
            kabiwangEntities ef = new kabiwangEntities();
            ef.Database.Connection.ConnectionString = scsb.ConnectionString;

            //更新從網頁上來的意見
            try
            {
                var chance = ef.UserId.FirstOrDefault(n => n.Name == gift.Name);
                if (chance.Chance > 0)
                {
                    Gift insertGifts = new Gift()
                    {
                        Name = gift.Name,
                        NowTime = DateTime.Now.ToLocalTime(),
                        Content = gift.Content
                    };
                    chance.Chance -= 1;
                    ef.Gift.Add(insertGifts);
                    ef.SaveChanges();
                    return "寶貴的抽獎次數-1 還有" + $"{chance.Chance}次";
                }
                else
                    return "沒有抽獎次數囉 Q.Q";
            }
            catch
            {
                return "查詢不到你，請聯絡帥氣的工程師hehe";
            }
        }
        public void ChangeEF(ref int? chance, UserId name, UserId myname, UserId comment, UserId changeChance, kabiwangEntities ef)
        {
            if (myname != null)
            {
                chance += 1;
                changeChance.LotteryMyName = true;
                changeChance.Chance = chance;
                ef.SaveChanges();
            }
            if (name != null)
            {
                chance += 1;
                changeChance.LotteryName = true;
                changeChance.Chance = chance;
                ef.SaveChanges();
            }
            if (comment != null)
            {
                chance += 1;
                changeChance.LotteryComment = true;
                changeChance.Chance = chance;
                ef.SaveChanges();
            }
        }
        #region
        //剩餘學習目標querystring json 的傳接
        //json
        [HttpGet]
        [ActionName("aabbcc")]
        public string Testjson(string id)
        {
            return id;
        }
        #endregion

    }
}
