<?php

namespace Database\Seeders;

use App\Models\Admin;
use App\Models\game;
use App\Models\User;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    use WithoutModelEvents;

    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        // User::factory(10)->create();

        User::forceCreate([
            'name' => 'player1',
            'password' => bcrypt('helloworld1')
        ]);
        User::forceCreate([
            'name' => 'player2',
            'password' => bcrypt('helloworld2')
        ]);

        $dev1 = User::forceCreate([
            'name' => 'dev1',
            'password' => bcrypt('hellobyte1')
        ]);

        $dev2 = User::forceCreate([
            'name' => 'dev2',
            'password' => bcrypt('hellobyte2')
        ]);

        game::forceCreate([
            'title' => 'Demo Game 1',
            'slug' => 'demo-game-1',
            'description' => 'This is a demo game 1',
            'author_id' => $dev1->id,
        ]);

                game::forceCreate([
            'title' => 'Demo Game 2',
            'slug' => 'demo-game-2',
            'description' => 'This is a demo game 2',
            'author_id' => $dev2->id,
        ]);


                Admin::forceCreate([
            'username' => 'admin1',
            'password' => bcrypt('hellouniverse1!')
    
        ]);

                        Admin::forceCreate([
            'username' => 'admin2',
            'password' => bcrypt('hellouniverse2!')
    
        ]);
        
    }
}
