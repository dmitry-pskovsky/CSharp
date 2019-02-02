package view;

import events.ISlabListener;
import model.Slab;

import javax.swing.*;
import java.awt.*;
import java.awt.font.FontRenderContext;
import java.awt.font.TextAttribute;
import java.awt.geom.Rectangle2D;
import java.awt.geom.RoundRectangle2D;
import java.text.AttributedCharacterIterator;
import java.text.AttributedString;

/**
 * Created by dimap on 10/13/2015.
 */
public class SlabView extends JComponent implements ISlabListener {

    private Point _position = new Point(50, 50);
    private Point _location = new Point(0, 0);

    public int width = 100;
    public int height = 100;

    private GridView _gridView;
    private int _value = 16384;

    public void SlabView() {

    }

    public void initialize(GridView gridView, Slab slab) {
        _gridView = gridView;
        slab.initializeSlabListener(this);
        _position = _gridView.getCoordsOfLocation(_location);

    }

    protected void draw(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D) g;

        int color = getSlabColor();
        int textColor = getTextColor();
        int textSize = getTextSize();

        g2.setColor(new Color(color));
        g2.setStroke(new BasicStroke(2));
        g2.fillRoundRect(_position.x, _position.y, width, height, 10, 10);

        drawNumber(g2, textColor, textSize);
    }

    private int getTextSize() {
        int textSize;
        int num = (int)Math.log10(_value)+1;
        switch (num) {
            case 1:
                textSize = 48;
                break;
            case 2:
                textSize = 48;
                break;
            case 3:
                textSize = 40;
                break;
            case 4:
                textSize = 35;
                break;
            case 5:
                textSize = 29;
                break;
            default:
                textSize = 48;
                break;
        }
        return textSize;
    }

    private int getTextColor() {
        int textColor;
        if(_value == 2 || _value == 4)
            textColor = 0x7d6e67;
        else
            textColor = 0xf9eff0;
        return textColor;
    }

    private int getSlabColor() {
        int color;
        switch (_value){
            case 2:
                color = 0xfae7e0;
                break;
            case 4:
                color = 0xf6e8cb;
                break;
            case 8:
                color = 0xfab37b;
                break;
            case 16:
                color = 0xec8d55;
                break;
            case 32:
                color = 0xf57c5f;
                break;
            case 64:
                color = 0xea593a;
                break;
            case 128:
                color = 0xfad177;
                break;
            case 256:
                color = 0xf7d067;
                break;
            case 512:
                color = 0xf9ca58;
                break;
            case 1024:
                color = 0xe3ba14;
                break;
            case 2048:
                color = 0xf9ca58;
                break;
            case 4096:
                color = 0xf46674;
                break;
            case 8192:
                color = 0xf34b5c;
                break;
            case 16384:
                color = 0xeb4141;
                break;
            default:
                color = 0xffffff;
                break;
        }
        return color;
    }

    private void drawNumber(Graphics2D g2, int color, int textSize) {

        g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        g2.setColor(new Color(color));
        g2.setFont(new Font("Arial black", Font.PLAIN, textSize));
        FontRenderContext frc = g2.getFontRenderContext();
        String s = String.valueOf(_value);
        Rectangle2D bounds = g2.getFont().getStringBounds(s, frc);
        float textWidth = (float) bounds.getWidth();
        float textHeight = (float) bounds.getHeight();
        g2.drawString(s, _position.x + width / 2 - textWidth / 2, _position.y + (-(int)bounds.getY()) + height / 2 - textHeight / 2);
    }

    public void keyDownPressed() {
        _location = new Point(_location.x,_location.y + 1);
        _position = _gridView.getCoordsOfLocation(_location);
    }

    public void keyUpPressed() {
        _location = new Point(_location.x,_location.y - 1);
        _position = _gridView.getCoordsOfLocation(_location);
    }

    public void keyRightPressed() {
        _location = new Point(_location.x + 1, _location.y);
        _position = _gridView.getCoordsOfLocation(_location);
    }

    public void keyLeftPressed() {
        _location = new Point(_location.x - 1, _location.y);
        _position = _gridView.getCoordsOfLocation(_location);
    }

    @Override
    public void initializeView(Point location, int value) {
        _location = location;
        _value = value;
    }

    @Override
    public void moveToLocation(Point location) {
        _position = _gridView.getCoordsOfLocation(location);
    }

    @Override
    public void remove() {
        _gridView.removeSlab(_location);
    }

    public Point getLocation() {
        return _location;
    }

    @Override
    public void up(int value) {
        _value = value;
    }
}


