using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataGen.Data
{
    class Generator
    {
        private int maxMySourceId;
        private int maxCommentId;
        private readonly GenDao dao;
        private readonly MyProgress progress;
        private readonly DgSettings settings;

        public Generator(GenDao dao, int maxMySourceId, int maxCommentId, MyProgress progress, DgSettings settings)
        {
            this.settings = settings;
            this.progress = progress;
            this.dao = dao;
            this.maxMySourceId = maxMySourceId;
            this.maxCommentId = maxCommentId;
        }

        public async Task Insert(int count)
        {
            var up = count;

            try
            {
                for (var i = 0; i < up; i++)
                {
                    await InsertSingle();
                }
            }
            catch(Exception x)
            {
                var m = x.Message;
                if (Debugger.IsAttached)
                {
                    Debugger.Break();    
                }
            }
        }

        async Task InsertSingle()
        {
            maxMySourceId++;

            var x = maxMySourceId;

            var ms = CreateMySource(x);
            await dao.Insert(ms);
            

            this.progress.AddDone();

            //if (settings.BothEntities)
            //{
                maxCommentId++;
                var gr = CreateComment(maxCommentId);
                await dao.Insert(gr);

                this.progress.AddDone();
            //}
        }

        static MySource CreateMySource(int x)
        {
            var r = new MySource
            {
                Id1 = x,
                Id2 = 0,
                Title = "t " + x,
                Description = "d " + x
            };

            r.IdU = r.Id1 * 10 + r.Id2;

            return r;
        }

        static Comment CreateComment(int id)
        {
            var r = new Comment
            {
                Id = id,
                Text = string.Format("I have commented {0} times",id),
                CategoryId=0,
                MoodId = 2 ,
                AuthorId = (id-1) % 3 +1
            };

            return r;
        }

    }
}
