﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTextRPG.Scene
{
    enum SceneType
    {
        None, 
        StartScene,         // 시작화면 
        StatusScene,        // 상태보기
        Inventory,          // 인벤토리
        Store,              // 상점 
    }
    class SceneBase
    {
        private SceneType nextScene;
        public SceneType NextScene { get => nextScene; set => nextScene = value; }
        public virtual void Start()
        {
            nextScene = SceneType.None;
        }
        public virtual void Update()
        {

        }
    }
}
