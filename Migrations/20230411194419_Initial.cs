﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BYUEgypt.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "excelimporter$template_nr_mxseq");

            migrationBuilder.CreateSequence(
                name: "system$filedocument_fileid_mxseq");

            migrationBuilder.CreateSequence(
                name: "system$queuedtask_sequence_mxseq");

            migrationBuilder.CreateTable(
                name: "analysis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    analysistype = table.Column<int>(type: "integer", nullable: true),
                    doneby = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    analysisid = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analysis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "analysis_textile",
                columns: table => new
                {
                    mainanalysisid = table.Column<long>(name: "main$analysisid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$analysis_textile_pkey", x => new { x.mainanalysisid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "artifactfagelgamousregister",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    registernum = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    photographed = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    coordinateset = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artifactfagelgamousregister", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "artifactfagelgamousregister_burialmain",
                columns: table => new
                {
                    mainartifactfagelgamousregisterid = table.Column<long>(name: "main$artifactfagelgamousregisterid", type: "bigint", nullable: false),
                    mainburialmainid = table.Column<long>(name: "main$burialmainid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$artifactfagelgamousregister_burialmain_pkey", x => new { x.mainartifactfagelgamousregisterid, x.mainburialmainid });
                });

            migrationBuilder.CreateTable(
                name: "artifactkomaushimregister",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    provenance = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    position = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    qualityphotos = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    finder = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    dimensions = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    material = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    rehousedto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    photos = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    number = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    entrydate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    currentlocation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    excavatornum = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    date = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artifactkomaushimregister", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "artifactkomaushimregister_burialmain",
                columns: table => new
                {
                    mainartifactkomaushimregisterid = table.Column<long>(name: "main$artifactkomaushimregisterid", type: "bigint", nullable: false),
                    mainburialmainid = table.Column<long>(name: "main$burialmainid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$artifactqumoshimregistrar_burialmain_pkey", x => new { x.mainartifactkomaushimregisterid, x.mainburialmainid });
                });

            migrationBuilder.CreateTable(
                name: "biological",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    racknumber = table.Column<int>(type: "integer", nullable: true),
                    bagnumber = table.Column<int>(type: "integer", nullable: true),
                    previouslysampled = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    initials = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    clusternumber = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biological", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "biological_c14",
                columns: table => new
                {
                    mainbiologicalid = table.Column<long>(name: "main$biologicalid", type: "bigint", nullable: false),
                    mainc14id = table.Column<long>(name: "main$c14id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$biological_c14_pkey", x => new { x.mainbiologicalid, x.mainc14id });
                });

            migrationBuilder.CreateTable(
                name: "bodyanalysischart",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    femur = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    humerusheaddiameter = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    squamossuture = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    caries_periodontal_disease = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    medical_ip_ramus = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    perservationindex = table.Column<int>(type: "integer", nullable: true),
                    gonion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    humeruslength = table.Column<int>(type: "integer", nullable: true),
                    femurlength = table.Column<int>(type: "integer", nullable: true),
                    lambdoidsuture = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ventralarc = table.Column<bool>(type: "boolean", nullable: true),
                    tootheruptionageestimation = table.Column<int>(type: "integer", nullable: true),
                    nuchalcrest = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    estimatestature = table.Column<int>(type: "integer", nullable: true),
                    notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    osteophytosis = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    subpubicangle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    robust = table.Column<bool>(type: "boolean", nullable: true),
                    femurheaddiameter = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sciaticnotch = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    supraorbitalridges = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    orbitedge = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    toothattrition = table.Column<int>(type: "integer", nullable: true),
                    sphenooccipitalsynchondrosis = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    parietalblossing = table.Column<bool>(type: "boolean", nullable: true),
                    observations = table.Column<string>(type: "character varying", nullable: true),
                    humerus = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodyanalysischart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    author = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    link = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "burialmain",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    squarenorthsouth = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    headdirection = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sex = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    northsouth = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    depth = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    eastwest = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    adultsubadult = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    facebundles = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    southtohead = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    preservation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    fieldbookpage = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    squareeastwest = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    goods = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    text = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    wrapping = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    haircolor = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    westtohead = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    samplescollected = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    area = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    burialid = table.Column<long>(type: "bigint", nullable: true),
                    length = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    burialnumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    dataexpertinitials = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    westtofeet = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ageatdeath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    southtofeet = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    excavationrecorder = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    photos = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    hair = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    burialmaterials = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    dateofexcavation = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fieldbookexcavationyear = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    clusternumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    shaftnumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burialmain", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "burialmain_biological",
                columns: table => new
                {
                    mainburialmainid = table.Column<long>(name: "main$burialmainid", type: "bigint", nullable: false),
                    mainbiologicalid = table.Column<long>(name: "main$biologicalid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$burialmain_biological_pkey", x => new { x.mainburialmainid, x.mainbiologicalid });
                });

            migrationBuilder.CreateTable(
                name: "burialmain_bodyanalysischart",
                columns: table => new
                {
                    mainburialmainid = table.Column<long>(name: "main$burialmainid", type: "bigint", nullable: false),
                    mainbodyanalysischartid = table.Column<long>(name: "main$bodyanalysischartid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$burialmain_bodyanalysischart_pkey", x => new { x.mainburialmainid, x.mainbodyanalysischartid });
                });

            migrationBuilder.CreateTable(
                name: "burialmain_cranium",
                columns: table => new
                {
                    mainburialmainid = table.Column<long>(name: "main$burialmainid", type: "bigint", nullable: false),
                    maincraniumid = table.Column<long>(name: "main$craniumid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$burialmain_cranium_pkey", x => new { x.mainburialmainid, x.maincraniumid });
                });

            migrationBuilder.CreateTable(
                name: "burialmain_textile",
                columns: table => new
                {
                    mainburialmainid = table.Column<long>(name: "main$burialmainid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$burialmain_textile_pkey", x => new { x.mainburialmainid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "c14",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    category = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    size = table.Column<int>(type: "integer", nullable: true),
                    agebp = table.Column<int>(type: "integer", nullable: true),
                    calibratedspan = table.Column<int>(type: "integer", nullable: true),
                    tubenumber = table.Column<int>(type: "integer", nullable: true),
                    calibrateddatemin = table.Column<int>(type: "integer", nullable: true),
                    calibrateddateavg = table.Column<int>(type: "integer", nullable: true),
                    foci = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    rack = table.Column<int>(type: "integer", nullable: true),
                    calendardate = table.Column<int>(type: "integer", nullable: true),
                    calibrateddatemax = table.Column<int>(type: "integer", nullable: true),
                    c14lab = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    questions = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    location = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_c14", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    colorid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "color_textile",
                columns: table => new
                {
                    maincolorid = table.Column<long>(name: "main$colorid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$color_textile_pkey", x => new { x.maincolorid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "cranium",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    interobital_breadth = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    max_nasal_breadth = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    basion_nasion = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    interorbital_breadth = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    nasion_prosthion_upper = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    naso_alpha__subtense = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    basion_bregma_height = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    maxcraniumlength = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    interorbital_subtense = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    basion_prosthion_length = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    alpha_core = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    mid_orbital_subtense = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    maxcraniumbreadth = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    bizygomatic_diameter = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true),
                    mid_orbital_breadth = table.Column<decimal>(type: "numeric(28,8)", precision: 28, scale: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cranium", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "decoration",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    decorationid = table.Column<int>(type: "integer", nullable: true),
                    value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_decoration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "decoration_textile",
                columns: table => new
                {
                    maindecorationid = table.Column<long>(name: "main$decorationid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$decoration_textile_pkey", x => new { x.maindecorationid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "dimension",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    dimensiontype = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    value = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    dimensionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dimension", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dimension_textile",
                columns: table => new
                {
                    maindimensionid = table.Column<long>(name: "main$dimensionid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$dimension_textile_pkey", x => new { x.maindimensionid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "newsarticle",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    author = table.Column<string>(type: "character varying", nullable: true),
                    title = table.Column<string>(type: "character varying", nullable: true),
                    urltoimage = table.Column<string>(type: "character varying", nullable: true),
                    url = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsarticle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "photodata",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    filename = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    photodataid = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photodata", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "photodata_textile",
                columns: table => new
                {
                    mainphotodataid = table.Column<long>(name: "main$photodataid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$photodata_textile_pkey", x => new { x.mainphotodataid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "photoform",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    area = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    squarenorthsouth = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    tableassociation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    filename = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    photographer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    burialnumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    squareeastwest = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    eastwest = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    northsouth = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    photodate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photoform", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structure",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    structureid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_structure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structure_textile",
                columns: table => new
                {
                    mainstructureid = table.Column<long>(name: "main$structureid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$structure_textile_pkey", x => new { x.mainstructureid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "teammember",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    bio = table.Column<string>(type: "character varying", nullable: true),
                    membername = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teammember", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "textile",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    locale = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    textileid = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    burialnumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    estimatedperiod = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sampledate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    photographeddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    direction = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_textile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "textilefunction",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    textilefunctionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_textilefunction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "textilefunction_textile",
                columns: table => new
                {
                    maintextilefunctionid = table.Column<long>(name: "main$textilefunctionid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$textilefunction_textile_pkey", x => new { x.maintextilefunctionid, x.maintextileid });
                });

            migrationBuilder.CreateTable(
                name: "yarnmanipulation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    thickness = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    angle = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    manipulation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    material = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    count = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    component = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ply = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    yarnmanipulationid = table.Column<int>(type: "integer", nullable: true),
                    direction = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yarnmanipulation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "yarnmanipulation_textile",
                columns: table => new
                {
                    mainyarnmanipulationid = table.Column<long>(name: "main$yarnmanipulationid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$yarnmanipulation_textile_pkey", x => new { x.mainyarnmanipulationid, x.maintextileid });
                });

            migrationBuilder.CreateIndex(
                name: "idx_main$analysis_textile_main$textile_main$analysis",
                table: "analysis_textile",
                columns: new[] { "main$textileid", "main$analysisid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$artifactfagelgamousregister_burialmain",
                table: "artifactfagelgamousregister_burialmain",
                columns: new[] { "main$burialmainid", "main$artifactfagelgamousregisterid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$artifactkomaushimregister_burialmain",
                table: "artifactkomaushimregister_burialmain",
                columns: new[] { "main$burialmainid", "main$artifactkomaushimregisterid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$biological_c14_main$c14_main$biological",
                table: "biological_c14",
                columns: new[] { "main$c14id", "main$biologicalid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$burialmain_biological_main$biological_main$burialmain",
                table: "burialmain_biological",
                columns: new[] { "main$biologicalid", "main$burialmainid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$burialmain_bodyanalysischart",
                table: "burialmain_bodyanalysischart",
                columns: new[] { "main$bodyanalysischartid", "main$burialmainid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$burialmain_cranium_main$cranium_main$burialmain",
                table: "burialmain_cranium",
                columns: new[] { "main$craniumid", "main$burialmainid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$burialmain_textile_main$textile_main$burialmain",
                table: "burialmain_textile",
                columns: new[] { "main$textileid", "main$burialmainid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$color_textile_main$textile_main$color",
                table: "color_textile",
                columns: new[] { "main$textileid", "main$colorid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$decoration_textile_main$textile_main$decoration",
                table: "decoration_textile",
                columns: new[] { "main$textileid", "main$decorationid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$dimension_textile_main$textile_main$dimension",
                table: "dimension_textile",
                columns: new[] { "main$textileid", "main$dimensionid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$photodata_textile_main$textile_main$photodata",
                table: "photodata_textile",
                columns: new[] { "main$textileid", "main$photodataid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$structure_textile_main$textile_main$structure",
                table: "structure_textile",
                columns: new[] { "main$textileid", "main$structureid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$textilefunction_textile",
                table: "textilefunction_textile",
                columns: new[] { "main$textileid", "main$textilefunctionid" });

            migrationBuilder.CreateIndex(
                name: "idx_main$yarnmanipulation_textile",
                table: "yarnmanipulation_textile",
                columns: new[] { "main$textileid", "main$yarnmanipulationid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analysis");

            migrationBuilder.DropTable(
                name: "analysis_textile");

            migrationBuilder.DropTable(
                name: "artifactfagelgamousregister");

            migrationBuilder.DropTable(
                name: "artifactfagelgamousregister_burialmain");

            migrationBuilder.DropTable(
                name: "artifactkomaushimregister");

            migrationBuilder.DropTable(
                name: "artifactkomaushimregister_burialmain");

            migrationBuilder.DropTable(
                name: "biological");

            migrationBuilder.DropTable(
                name: "biological_c14");

            migrationBuilder.DropTable(
                name: "bodyanalysischart");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "burialmain");

            migrationBuilder.DropTable(
                name: "burialmain_biological");

            migrationBuilder.DropTable(
                name: "burialmain_bodyanalysischart");

            migrationBuilder.DropTable(
                name: "burialmain_cranium");

            migrationBuilder.DropTable(
                name: "burialmain_textile");

            migrationBuilder.DropTable(
                name: "c14");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "color_textile");

            migrationBuilder.DropTable(
                name: "cranium");

            migrationBuilder.DropTable(
                name: "decoration");

            migrationBuilder.DropTable(
                name: "decoration_textile");

            migrationBuilder.DropTable(
                name: "dimension");

            migrationBuilder.DropTable(
                name: "dimension_textile");

            migrationBuilder.DropTable(
                name: "newsarticle");

            migrationBuilder.DropTable(
                name: "photodata");

            migrationBuilder.DropTable(
                name: "photodata_textile");

            migrationBuilder.DropTable(
                name: "photoform");

            migrationBuilder.DropTable(
                name: "structure");

            migrationBuilder.DropTable(
                name: "structure_textile");

            migrationBuilder.DropTable(
                name: "teammember");

            migrationBuilder.DropTable(
                name: "textile");

            migrationBuilder.DropTable(
                name: "textilefunction");

            migrationBuilder.DropTable(
                name: "textilefunction_textile");

            migrationBuilder.DropTable(
                name: "yarnmanipulation");

            migrationBuilder.DropTable(
                name: "yarnmanipulation_textile");

            migrationBuilder.DropSequence(
                name: "excelimporter$template_nr_mxseq");

            migrationBuilder.DropSequence(
                name: "system$filedocument_fileid_mxseq");

            migrationBuilder.DropSequence(
                name: "system$queuedtask_sequence_mxseq");
        }
    }
}
