using System;
using SyncApp2.Authors;
using Dafist.Engine.Conversion;
using Dafist.Engine.Resilience.SchemaErrors;
using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Schemas.Mappings;

namespace SyncApp2.SchemaDef
{
    public class CommentSf
    {
        private readonly AuthorsDao authorsDao;

        public CommentSf(AuthorsDao authorsDao)
        {
            this.authorsDao = authorsDao;
        }

        public SourceEntity Create()
        {
            var sourceEntity = new SourceEntity(
                name: "Comment",
                idFields: new[] {"Id"},
                ordinaryFields: new[] { "Text","CategoryId", "MoodId", "AuthorId" });

            var ms1Mapping = MappingFactory.Create(sourceEntity, 
                new TargetEntity(
                    name: "Comment1", 
                    fields:new TargetField[]
                    {
                        new Copy("Id"),
                        new Copy("Text"),
                        new Custom("Type", f => f["Text"].AsString().Length<10?"short":"long"),

                        new Copy("CategoryId"),

                        new Copy("MoodId"), 
                        new Custom("Emoji", f => f["MoodId"].AsInt()>1?":-)":":-("),

                        new Copy("AuthorId"),
                        new Custom("AuthorScore", f => GetAuthorScore(f["AuthorId"].AsInt()))
                    }));

            var ms2Mapping = MappingFactory.Create(sourceEntity, 
                new TargetEntity(
                    name: "Comment2", 
                    fields: new TargetField[]
                    {
                        new Auto("Id"),

                        new Copy("Text"),
                        new Copy("CategoryId"),

                        new Custom("Mood", f => f["MoodId"].AsInt()>1?"Happy":"Unhappy"),

                        new Copy("IdC", "Id"),
                    }));

            var rbMapping = MappingFactory.Create(sourceEntity, 
                new TargetEntity(
                    name: "Commentm",
                    fields: new TargetField[]
                    {
                        new Copy("Id"),
                        new Copy("Text"),
                        new Copy("CategoryId"),
                        new Copy("MoodId"), 
                        new Copy("AuthorId"),
                        new Custom("AuthorScore", f => GetAuthorScore(f["AuthorId"].AsInt()))
                    }));

            var mf = MappingFinder.CreateIdBasedLookup()
                        .Add(ConsumerIds.Ms1, ms1Mapping)
                        .Add(ConsumerIds.Ms2, ms2Mapping)
                        .Add(ConsumerIds.Rb, rbMapping);

            //var mf2 = new MappingFinder.FuncBased(c=>c.Id.AsInt()<2?ms1Mapping:ms2Mapping);
            //sourceEntity.SetMappings(mf2);

            sourceEntity.SetMappings(mf);

            return sourceEntity;
        }

        int GetAuthorScore(int authorId)
        {
            Author a;
            try
            {
                a = authorsDao.LoadAuthor(authorId);
            }
            catch (Exception x)
            {
                throw new ExternalSystemNotAvailableException("failed to load the author",x);
            }
            
            if (a == null)
            {
                throw new InvalidSourceDataException(string.Format("Author with Id={0} not found", authorId));
            }

            if (!a.IsActive)
            {
                throw new InvalidSourceDataException(string.Format("Author with Id={0} is not active", authorId));
            }

            return a.Score;
        }

    }
}
