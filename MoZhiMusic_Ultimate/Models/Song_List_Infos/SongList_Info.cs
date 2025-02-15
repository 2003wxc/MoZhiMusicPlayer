﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoZhiMusic_Ultimate.Models.Song_List_Infos
{
    public class SongList_Info
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Song_Info> Songs { get; set; }
        public int SelectedIndex { get; set; }

        public static List<List<Models.Song_List_Infos.SongList_Info>> songList_Infos { get; set; }
        public static List<List<Models.Song_List_Infos.SongList_Info>> Retuen_This()
        {
            songList_Infos = Return_This_SongList_Info();
            return songList_Infos;
        }
        private static List<List<Models.Song_List_Infos.SongList_Info>> Return_This_SongList_Info()
        {
            if (songList_Infos == null)
                songList_Infos = new List<List<Models.Song_List_Infos.SongList_Info>>();

            return songList_Infos;
        }

        public static implicit operator List<object>(SongList_Info v)
        {
            throw new NotImplementedException();
        }
    }
}
