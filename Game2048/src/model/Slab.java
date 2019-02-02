package model;

import events.ISlabListener;
import events.KeyEventListener;

import java.awt.*;

/**
 * Created by dimap on 10/15/2015.
 */
public class Slab implements KeyEventListener {

    Point location;
    Grid grid;
    int value;
    ISlabListener iSlabListener;

    public Slab(Grid grid, Point location) {
        this.location = location;
        this.value = 2;
        this.grid = grid;
    }

    public int getValue() {
        return value;
    }

    public void initializeSlabListener(ISlabListener iSlabListener) {
        this.iSlabListener = iSlabListener;
        iSlabListener.initializeView(location, value);
    }

    public void up() {
        value *= 2;
        iSlabListener.up(value);
    }

    public void remove() {
        iSlabListener.remove();
        iSlabListener = null;
    }


    private void moveToLocation(Point location) {
        grid.removeSlab(this.location);
        this.location = location;
        grid.addSlab(this, location);
        iSlabListener.moveToLocation(location);
    }

    @Override
    public void keyDownPressed() {
        int y = location.y;
        while (grid.isLocationEmpty(new Point(location.x, y + 1), value)) {
            y++;
        }
        if(location.y != y)
            moveToLocation(new Point(location.x, y));
    }

    @Override
    public void keyUpPressed() {
        int y = location.y;
        while (grid.isLocationEmpty(new Point(location.x, y - 1), value)) {
            y--;
        }
        if(location.y != y)
            moveToLocation(new Point(location.x, y));
    }

    @Override
    public void keyRightPressed() {
        int x = location.x;
        while (grid.isLocationEmpty(new Point(x + 1, location.y), value)) {
            x++;
        }
        if(location.x != x)
            moveToLocation(new Point(x, location.y));
    }

    @Override
    public void keyLeftPressed() {
        int x = location.x;
        while (grid.isLocationEmpty(new Point(x - 1, location.y), value)) {
            x--;
        }
        if(location.x != x)
            moveToLocation(new Point(x, location.y));
    }
}
