# 🎯 Aim Trainer - Unity 3D

Ek intense training ground jahan aap apni shooting accuracy improve kar sakte hain. Ismein bots spawn hote hain aur ek khatarnak "Berserk AI Enemy" hai jo player ka picha karta hai.

## ✨ Features
* **Weapon System:** Realistic AK47/M1911 mechanics with Ammo Management and Reloading.
* **Berserk AI Enemy:** Naya twist! Enemy ki health jitni kam hogi, uska damage aur speed utni hi badh jayegi.
* **Teasing Voices:** Enemy player ko beech-beech mein voice lines se tease karta hai.
* **Auto-Spawner:** Scene mein hamesha 5 targets maintain rakhta hai.
* **Dynamic UI:** Legacy Text system for real-time Score and Ammo display.

## 🛠️ Setup Instructions
1.  **Tagging:** Capsule Prefabs ko `Target` tag assign karein.
2.  **Audio Fix:** Weapon Camera se `Audio Listener` component remove karein taaki duplicate error na aaye.
3.  **UI Linking:** Hierarchy se apne "Score Board" text ko `ScoreManager` script ke slot mein drag karein.
4.  **AI Navigation:** Ground ko "Static" mark karke `Navigation` window se "Bake" karein taaki Enemy rasta dhoond sake.
