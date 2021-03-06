﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Server.Data;
using System;

namespace Server.Migrations
{
    [DbContext(typeof(FaceRequestContext))]
    [Migration("20180522183104_Adds_CreationDateTimeAndIsCompleted")]
    partial class Adds_CreationDateTimeAndIsCompleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Server.Models.FaceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorizationCode");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("RequestedFaceId");

                    b.HasKey("Id");

                    b.ToTable("FaceRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
