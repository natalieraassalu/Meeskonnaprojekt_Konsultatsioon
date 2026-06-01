using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class BookingCourseContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                IF COL_LENGTH('BookingPage', 'CourseId') IS NULL
                BEGIN
                    ALTER TABLE [BookingPage] ADD [CourseId] uniqueidentifier NULL;
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1
                    FROM sys.indexes
                    WHERE name = 'IX_BookingPage_CourseId'
                        AND object_id = OBJECT_ID('BookingPage')
                )
                BEGIN
                    CREATE INDEX [IX_BookingPage_CourseId] ON [BookingPage] ([CourseId]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1
                    FROM sys.foreign_keys
                    WHERE name = 'FK_BookingPage_Courses_CourseId'
                )
                BEGIN
                    ALTER TABLE [BookingPage]
                    ADD CONSTRAINT [FK_BookingPage_Courses_CourseId]
                    FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]);
                END
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                IF EXISTS (
                    SELECT 1
                    FROM sys.foreign_keys
                    WHERE name = 'FK_BookingPage_Courses_CourseId'
                )
                BEGIN
                    ALTER TABLE [BookingPage] DROP CONSTRAINT [FK_BookingPage_Courses_CourseId];
                END
                """);

            migrationBuilder.Sql("""
                IF EXISTS (
                    SELECT 1
                    FROM sys.indexes
                    WHERE name = 'IX_BookingPage_CourseId'
                        AND object_id = OBJECT_ID('BookingPage')
                )
                BEGIN
                    DROP INDEX [IX_BookingPage_CourseId] ON [BookingPage];
                END
                """);

            migrationBuilder.Sql("""
                IF COL_LENGTH('BookingPage', 'CourseId') IS NOT NULL
                BEGIN
                    ALTER TABLE [BookingPage] DROP COLUMN [CourseId];
                END
                """);
        }
    }
}
