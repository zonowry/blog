﻿// <auto-generated />
using System;
using Blog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.DbMigrator.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    partial class BlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ArticleRecordTagRecord", b =>
                {
                    b.Property<int>("ArticlesID")
                        .HasColumnType("integer")
                        .HasColumnName("articles_id");

                    b.Property<string>("TagsID")
                        .HasColumnType("text")
                        .HasColumnName("tags_id");

                    b.HasKey("ArticlesID", "TagsID")
                        .HasName("pk_article_tags");

                    b.HasIndex("TagsID")
                        .HasDatabaseName("ix_article_tags_tags_id");

                    b.ToTable("article_tags");
                });

            modelBuilder.Entity("Blog.Infrastructure.Models.CommentRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer")
                        .HasColumnName("article_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("content");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(48)")
                        .HasColumnName("name");

                    b.Property<int?>("RootId")
                        .HasColumnType("integer")
                        .HasColumnName("root_id");

                    b.Property<int?>("TargetId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("target_id");

                    b.Property<string>("WebSite")
                        .IsRequired()
                        .HasColumnType("varchar(512)")
                        .HasColumnName("web_site");

                    b.HasKey("Id")
                        .HasName("pk_comment");

                    b.HasIndex("ArticleId")
                        .HasDatabaseName("ix_comment_article_id");

                    b.HasIndex("RootId")
                        .IsUnique()
                        .HasDatabaseName("ix_comment_root_id");

                    b.HasIndex("TargetId")
                        .HasDatabaseName("ix_comment_target_id");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("Blog.Infrastructure.Models.TagRecord", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("value");

                    b.HasKey("ID")
                        .HasName("pk_tags");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("Blog.Infrastructure.Records.ArticleAccessLogRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ArticleID")
                        .HasColumnType("integer")
                        .HasColumnName("article_id");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_data");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("ip");

                    b.HasKey("Id")
                        .HasName("pk_article_access_log");

                    b.HasIndex("ArticleID")
                        .HasDatabaseName("ix_article_access_log_article_id");

                    b.ToTable("article_access_log");
                });

            modelBuilder.Entity("Blog.Infrastructure.Records.ArticleRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessCounts")
                        .HasColumnType("integer")
                        .HasColumnName("access_counts");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasColumnName("code");

                    b.Property<int>("CommentCounts")
                        .HasColumnType("integer")
                        .HasColumnName("comment_counts");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("state");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("sub_title");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("summary");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(512)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_date");

                    b.HasKey("ID")
                        .HasName("pk_article");

                    b.ToTable("article");
                });

            modelBuilder.Entity("Blog.Infrastructure.Records.AuditRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("ip");

                    b.HasKey("Id")
                        .HasName("pk_audits");

                    b.ToTable("audits");
                });

            modelBuilder.Entity("ArticleRecordTagRecord", b =>
                {
                    b.HasOne("Blog.Infrastructure.Records.ArticleRecord", null)
                        .WithMany()
                        .HasForeignKey("ArticlesID")
                        .HasConstraintName("fk_article_tags_article_articles_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Infrastructure.Models.TagRecord", null)
                        .WithMany()
                        .HasForeignKey("TagsID")
                        .HasConstraintName("fk_article_tags_tags_tags_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blog.Infrastructure.Models.CommentRecord", b =>
                {
                    b.HasOne("Blog.Infrastructure.Records.ArticleRecord", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .HasConstraintName("fk_comment_article_article_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Infrastructure.Models.CommentRecord", null)
                        .WithOne()
                        .HasForeignKey("Blog.Infrastructure.Models.CommentRecord", "RootId")
                        .HasConstraintName("fk_comment_comment_comment_record_id");

                    b.HasOne("Blog.Infrastructure.Models.CommentRecord", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .HasConstraintName("fk_comment_comment_target_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Blog.Infrastructure.Records.ArticleAccessLogRecord", b =>
                {
                    b.HasOne("Blog.Infrastructure.Records.ArticleRecord", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleID")
                        .HasConstraintName("fk_article_access_log_article_article_id");

                    b.Navigation("Article");
                });
#pragma warning restore 612, 618
        }
    }
}
