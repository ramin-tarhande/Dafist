using System;
using Dafist.Engine.Conversion;
using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Schemas.Mappings;

namespace SyncApp2.SchemaDef
{
    public class MySourceSf
    {
        public SourceEntity Create()
        {
            var sourceEntity = new SourceEntity(
                name: "MySource",
                idFields: new[] { "Id1", "Id2" },
                ordinaryFields: new[] { "Title", "Description", "IdU" });

            var msMapping = MappingFactory.Create(sourceEntity, 
                new TargetEntity(
                    name: "MyTarget",
                    fields: new TargetField[]
                    {
                        new Copy("Title"),
                        new Copy("Descrip", "Description"),

                        new Custom("Extra", f => f["Title"].AsString() + " -- " + f["Description"].AsString()),

                        new Copy("Id01", "Id1"),
                        new Copy("Id02", "Id2"),
                        new Copy("IdUU", "IdU"),
                        new Custom("UpsertTime", f => DateTime.Now),

                        new Copy("Idx", "Id1") //use for: unique index violation
                    }));

            var rbMapping = MappingFactory.Create(sourceEntity, 
                new TargetEntity(
                    name: "MaTarget",
                    fields: new TargetField[]
                    {
                        new Custom("Text", f => f["Title"].AsString() + ": " + f["Description"].AsString()),
                    }));

            //exclude ConsumerIds.Ms2
            var mf = MappingFinder.CreateIdBasedLookup()
                        .Add(ConsumerIds.Ms1, msMapping)
                        .Add(ConsumerIds.Rb, rbMapping);
            
            sourceEntity.SetMappings(mf);
            
            return sourceEntity;
        }
    }
}

//new Custom("UpsertTime", f => DateTime.MinValue), //use for: SqlTypeException
//new Copy("Idx","Title") //use for: conversion error